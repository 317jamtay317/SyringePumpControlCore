using System;
using SyringePumpControlNetStandard.Annotations.Extensions;
using SyringePumpControlNetStandard.Models.Commands;

namespace SyringePumpControlNetStandard.Models
{
    public class Pump : PropertyChangedBaseClass, IPump, IDisposable
    {
        private readonly IPort _port;

        #region Constructors

        public Pump(IPort port)
        {
            _port = port;
        }

        public Pump(
            IPort port,
            int address, 
            PumpDirection direction, 
            float diameter, 
            float rate, 
            RateUnits rateUnits, 
            float volume, 
            Units volumeUnits):this(port)
        {
            PumpDirection = direction;
            Address = address;
            Diameter = diameter;
            Rate = rate;
            RateUnits = rateUnits;
            TargetVolume = new Volume(volume, volumeUnits);
        }
        

        #endregion

        #region Properties

        /// <summary>
        /// if the port is open we are connected
        /// </summary>
        public bool IsConnected => _port.IsOpen;

        /// <summary>
        /// The Pump address range between 00 and 99
        /// </summary>
        public int Address
        {
            get => GetValue<int>();
            set => SetValue(value);
        }
        
        /// <summary>
        /// The direction of the pump, by default the direction is infuse
        /// </summary>
        public PumpDirection PumpDirection
        {
            get => GetValue<PumpDirection>();
            set
            {
                SetValue(value);
                OnPropertyChanged(nameof(Direction));
            }
        }

        public string Direction
        {
            get => PumpDirection.ToCommandString();
        }

        /// <summary>
        /// the diameter of the syringe
        /// </summary>
        public float Diameter
        {
            get => GetValue<float>();
            set => SetValue(value);
        }
        
        /// <summary>
        /// the rate the the pump flows 
        /// </summary>
        public float Rate
        {
            get => GetValue<float>();
            set => SetValue(value);
        }
        
        /// <summary>
        /// Units while pump is flowing, default is uL/min
        /// </summary>
        public RateUnits RateUnits
        {
            get => GetValue<RateUnits>();
            set
            {
                SetValue(value);
                OnPropertyChanged(nameof(UnitRate));
            }
        }

        /// <summary>
        /// Parsed RateUnits string
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string UnitRate
        {
            get => RateUnits.ToCommandString();
        }

        public Volume TargetVolume
        {
            get => GetValue<Volume>();
            set => SetValue(value);
        }
        

        #endregion

        #region IPumpInterface

        public void Connect()
        {
            if (IsConnected) return;
            try
            {
                _port.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Disconnect()
        {
            try
            {
                if(IsConnected)
                    _port.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Send(IPumpCommand pumpCommand)
        {
            try
            {
                Connect();
                
                _port.WriteLine(pumpCommand.ToString());
                
                Disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateValues(PumpValues pumpValues)
        {
            try
            {
                foreach (var pumpCommand in pumpValues.ToCommands(Address))
                {
                    Send(pumpCommand);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region Deconstructor

        public void Deconstruct(out int address,
            out PumpDirection pumpDirection,
            out float diameter,
            out float rate,
            out RateUnits rateUnits, 
            out float volume,
            out Units units)
        {
            address = Address;
            pumpDirection = PumpDirection;
            rate = Rate;
            rateUnits = RateUnits;
            volume = TargetVolume.Value;
            units = TargetVolume.Unit;
            diameter = Diameter;
        } 

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _port?.Dispose();
        }

        #endregion
    }
}