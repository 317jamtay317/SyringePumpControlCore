namespace SyringePumpControlCore.Models.Commands
{
    public abstract class BasicCommand : IPumpCommand
    {
        public BasicCommand(int address)
        {
            Address = address;
            Suffix = "\r\n";
        }
        public abstract string Message { get; }
        public virtual int Address { get; }
        
        public virtual string Suffix { get; set; }
       
        public override string ToString()
        {
            return $"{Address}{Message}{Suffix}";
        }
    }
}