using System;
using System.Collections.Generic;
using SyringePumpControlNetStandard.Models;
using SyringePumpControlNetStandard.Models.Commands;

namespace SyringePumpControlNetStandard.Services
{
    public class PumpService:IPumpService, IDisposable
    {
        private readonly PumpChain _pumps;
        private readonly IPort _port;

        public PumpService(GetPumps getPumps)
        {
            _pumps = getPumps();
            _port = new Port();
            BuzzDelay = 50;
        }

        public long BuzzDelay { get; set; }
        
        public IEnumerable<string> PortNames => _port.GetPortNames();
        
        public void Start(int pumpAddress, float rate)
        {
            BuzzPump(pumpAddress);
            var pump = GetPump(pumpAddress);
            pump.Rate = rate;

            var startRequest = new StartCommand(pumpAddress);
            pump.SetCurrentValues();
            pump.Send(startRequest);
        }

        public void Start(int pumpAddress)
        {
            var pump = GetPump(pumpAddress);
            Start(pumpAddress, pump.Rate);
        }

        public void Stop(int pumpAddress)
        {
            var pump = GetPump(pumpAddress);
            var stopRequest = new StopCommand(pumpAddress);
            pump.Send(stopRequest);
        }

        public IPump GetPump(int pumpAddress)
        {
            if (_pumps.ContainsPump(pumpAddress) == false)
            {
                throw new ArgumentException($"The Pump:{pumpAddress} doesnt exist in the chain");
            }
            return _pumps.GetPump(pumpAddress);
        }

        public void BuzzPump(int pumpAddress)
        {
            var request = new BuzzCommand(pumpAddress, Switch.On);
            SendCommand(request, pumpAddress);

            var timeSpan = TimeSpan.FromMilliseconds(BuzzDelay);
            var delayedCommand = new DelayedCommand(timeSpan,  new BuzzCommand(pumpAddress, Switch.Off));

            delayedCommand.Start((parameters)=> TimerCallback((IPumpCommand)parameters[0]));
        }

        public void UpdateSinglePumpValues(int pumpAddress, PumpValues values)
        {
            var pump = GetPump(pumpAddress);
            pump.UpdateValues(values);
        }

        private void TimerCallback(IPumpCommand pumpCommand)
        {
            SendCommand(pumpCommand, pumpCommand.Address);
        }

        private void SendCommand(IPumpCommand pumpCommand, int address)
        {
            var pump = GetPump(address);
            pump.Send(pumpCommand);
        }

        public void Dispose()
        {
            _port?.Dispose();
        }
    }

    public delegate PumpChain GetPumps();

}