// See https://aka.ms/new-console-template for more information

using SyringePumpControlCore.Models;
using SyringePumpControlCore.Services;
using SyringePumpControlNetStandard.Services;

var port = new SyringePumpPort() { BaudRate=19200,Parity=System.IO.Ports.Parity.None, DataBits=8, StopBits=System.IO.Ports.StopBits.One};
var pumpA = new Pump(port);
var pumpChain = new PumpChain { pumpA };

IPumpService pumpService = new PumpService(()=> pumpChain);

Console.WriteLine("Port:");

foreach (var portName in port.GetPortNames())
{
    Console.WriteLine(portName);
}

var selectedPortName = Console.ReadLine();
port.PortName = selectedPortName;

var pump = pumpService.GetPump(0);
var pumpValues = new PumpValues("3ul", 14, 40, PumpDirection.Withdraw, Units.Microliters);
pump.UpdateValues(pumpValues);

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