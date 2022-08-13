using SyringePumpControlCore.Models;

namespace SyringePumpControlCore.Models.Commands
{
    public class BuzzCommand:BasicCommand
    {
        private readonly Switch _power;

        public BuzzCommand(int address, Switch power):base(address)
        {
            _power = power;
        }

        public override string Message => $"*BUZ{(int)_power}";
    }
}