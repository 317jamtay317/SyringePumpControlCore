using SyringePumpControlNetStandard.Models.CommandConstants;

namespace SyringePumpControlNetStandard.Models.Commands
{
    public class VolumeCommand:FloatCommand
    {
        public VolumeCommand(int address, float value) : base(address, value)
        {
            Message = "VOL";
        }

        public override string Message { get; }
    }

    public class VolumeUnitsCommand:ValueCommand<string>
    {
        public VolumeUnitsCommand(int address, Units unit) : base(address)
        {
            Message = "VOL";
            Value = unit == Units.MicroLiters? 
                UnitConversions.MicroLiters: 
                UnitConversions.MilliLiters;
        }

        public override string Message { get; }
    }
}