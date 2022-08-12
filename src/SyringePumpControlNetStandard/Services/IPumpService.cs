using System.Collections.Generic;
using SyringePumpControlNetStandard.Models;

namespace SyringePumpControlNetStandard.Services
{
    public interface IPumpService
    {
        IEnumerable<string> PortNames { get; }

        void Start(int pumpAddress, float rate);
        
        void Start(int pumpAddress);

        void Stop(int pumpAddress);

        IPump GetPump(int pumpAddress);

        void BuzzPump(int pumpAddress);

        void UpdateSinglePumpValues(int pumpAddress, PumpValues values);
        
    }
}