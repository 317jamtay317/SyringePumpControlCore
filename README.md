# SyringePumpControlCore

[![.NET](https://github.com/317jamtay317/NetStandardSyringePumpControl/actions/workflows/dotnet.yml/badge.svg)](https://github.com/317jamtay317/NetStandardSyringePumpControl/actions/workflows/dotnet.yml)

This is a package that can be used with .Net Framework and or .Net Core apps

You're free to use this.



**Usages**

```
  var port = new SyringePumpPort() 
  { 
    BaudRate=19200,
    Parity=Parity.None,
    DataBits=8,
    StopBits=StopBits.One
  };
  var pump = new Pump(port);
  var pumpChain = new PumpChain { pump };
  IPumpService pumpService = new PumpService(()=>pumpChain);
  
  
  var pumpInChain = pumpService.GetPump(0);
  var pumpValues = new PumpValues("3ul", 14, 40, PumpDirection.Withdraw, Units.Microliters);
  
  pump.UpdateValues(pumpValues);
  
  pumpService.Start(0);

```
