namespace SyringePumpControlNetStandard.Models.Commands
{
    public class StopCommand : BasicCommand
    {
        public StopCommand(int address) : base(address)
        {
            Message = "STP";
        }

        public override string Message { get; }
    }
}