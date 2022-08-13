namespace SyringePumpControlCore.Models.Commands
{
    public class PurgeCommand:BasicCommand
    {
        public PurgeCommand(int address) : base(address)
        {
            Message = "PUR";
        }

        public override string Message { get; }
    }
}