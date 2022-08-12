namespace SyringePumpControlNetStandard.Models.Commands
{
    public class RateCommand:FloatCommand
    {
        public RateCommand(int address, float value) : base(address, value)
        {
            Message = "RAT";
        }

        public override string Message { get; }
    }

}