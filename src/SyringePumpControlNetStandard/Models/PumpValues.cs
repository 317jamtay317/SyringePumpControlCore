using System.Collections.Generic;
using SyringePumpControlNetStandard.Models.Commands;

namespace SyringePumpControlNetStandard.Models
{
    public class PumpValues
    {
        public PumpValues(Volume volume, float diameter, float rate, PumpDirection pumpDirection, Units volumeUnits)
        {
            Volume = volume;
            Diameter = diameter;
            Rate = rate;
            PumpDirection = pumpDirection;
            VolumeUnits = volumeUnits;
        }
        public Volume Volume { get; }
        public float Diameter { get; }
        public float Rate { get; }
        public PumpDirection PumpDirection { get; }
        public Units VolumeUnits { get; }


        public IEnumerable<IPumpCommand> ToCommands(int pumpAddress)
        {
            yield return new VolumeCommand(pumpAddress, Volume.Value);
            yield return new DiameterCommand(pumpAddress, Diameter);
            yield return new RateCommand(pumpAddress, Rate);
            yield return new DirectionCommand(pumpAddress, PumpDirection);
            yield return new VolumeUnitsCommand(pumpAddress, VolumeUnits);
        }
    }
}