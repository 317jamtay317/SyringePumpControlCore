using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SyringePumpControlNetStandard.Models;
using SyringePumpControlNetStandard.Models.Commands;
using SyringePumpControlNetStandard.Services;

namespace SyringPumpTests.Services;

[TestClass]
public class PumpServiceTests
{
    private PumpService _pumpService;
    private Mock<IPump> _pumpMock;
    private PumpChain _pumpChain;

    [TestInitialize]
    public void Init()
    {
        _pumpMock = new Mock<IPump>();
        _pumpMock.Setup(x => x.Address).Returns(0);
        _pumpChain = new PumpChain(new[] { _pumpMock.Object });
        _pumpService = new PumpService(()=> _pumpChain);
    }

    [TestMethod]
    public void StartShouldBuzPump()
    {
        _pumpService.BuzzDelay = 1;
        _pumpService.Start(0);

        Thread.Sleep(2);
        
        _pumpMock.Verify(x=>x.Send(It.IsAny<BuzzCommand>()), Times.Exactly(2));
    }

    [TestMethod]
    public void StopShouldSendStopCommand()
    {
        _pumpService.Stop(0);
        _pumpMock.Verify(x=>x.Send(It.IsAny<StopCommand>()), Times.Once);
    }
    [TestMethod]
    public void StartShouldSendStartCommand()
    {
        _pumpService.Start(0);
        _pumpMock.Verify(x=>x.Send(It.IsAny<StartCommand>()), Times.Once);
    }
}