// See https://aka.ms/new-console-template for more information

using SyringePumpControlNetStandard.Models;
using SyringePumpControlNetStandard.Services;

var port = new Port();
var pumpA = new Pump(port)
{
    Address = 0, 
    Diameter = 14, 
    Rate = 30,
    PumpDirection = PumpDirection.Infuse,
    RateUnits = RateUnits.MicrolitersPerMinutes, 
    TargetVolume = "3ml"
};
var pumpChain = new PumpChain { pumpA };

IPumpService pumpService = new PumpService(()=> pumpChain);

Console.WriteLine("Port:");

foreach (var portName in port.GetPortNames())
{
    Console.WriteLine(portName);
}

var selectedPortName = Console.ReadLine();
port.PortName = selectedPortName;

while (true)
{
    Console.WriteLine("What would you like to do? (Start | Stop)");
    var selectedAction = Console.ReadLine();

    if (selectedAction.ToLower() == "start")
    {
        pumpService.Start(0);
    }
    if (selectedAction.ToLower() == "stop")
    {
        pumpService.Stop(0);
    }
}