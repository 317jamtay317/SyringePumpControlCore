namespace SyringePumpControlCore.Models.Commands
{
    public interface IPumpCommand
    {
        string Message { get; }
        
        int Address { get; }
    }
}