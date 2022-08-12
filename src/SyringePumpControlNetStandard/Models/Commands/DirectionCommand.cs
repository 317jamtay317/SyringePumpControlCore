using SyringePumpControlNetStandard.Models.CommandConstants;

namespace SyringePumpControlNetStandard.Models.Commands
{
    public class DirectionCommand:ValueCommand<string>
    {
        public DirectionCommand(int address, PumpDirection direction) : base(address)
        {
            Message = "DIR";

            Value = direction == PumpDirection.Infuse
                ? PumpDirectionConversions.Infuse
                : PumpDirectionConversions.Withdraw;
        }

        public override string Message { get; }
    }
}