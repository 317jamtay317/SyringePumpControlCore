namespace SyringePumpControlCore.Models.Commands
{
    public abstract class FloatCommand:ValueCommand<float>
    {
        protected FloatCommand(int address, float value) : base(address)
        {
            Value = value;
        }
    }
}