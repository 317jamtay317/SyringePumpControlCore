namespace SyringePumpControlNetStandard.Models.Commands
{
    public abstract class ValueCommand<T>:BasicCommand
    {
        protected ValueCommand(int address ):base(address) { }
        
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Address}{Message}{Value}{Suffix}";
        }
    }
}