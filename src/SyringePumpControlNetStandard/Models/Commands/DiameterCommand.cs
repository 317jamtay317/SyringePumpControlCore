namespace SyringePumpControlNetStandard.Models.Commands
{
    public class DiameterCommand:FloatCommand
    {
        public DiameterCommand(int address, float value) : base(address, value)
        {
            Message = "DIA";
        }

        public override string Message { get; }
    }
}