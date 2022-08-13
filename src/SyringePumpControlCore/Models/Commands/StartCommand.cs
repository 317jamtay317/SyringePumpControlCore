namespace SyringePumpControlCore.Models.Commands
{
    public class StartCommand:BasicCommand
    {
        public StartCommand(int address) : base(address)
        {
            Message = "RUN";
        }

        public override string Message { get; }
    }
}