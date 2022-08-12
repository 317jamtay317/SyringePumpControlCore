using SyringePumpControlNetStandard.Annotations.Extensions;
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
            Value = unit.ToCommandString();
        }

        public override string Message { get; }
    }
}