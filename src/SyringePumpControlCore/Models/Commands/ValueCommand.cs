namespace SyringePumpControlCore.Models.Commands
{
    public abstract class ValueCommand<T>:BasicCommand
    {
        protected ValueCommand(int address ):base(address) { }
        
        public virtual T Value { get; set; }

        public override string ToString()
        {
            return $"{Address}{Message}{Value}{Suffix}";
        }
    }
}