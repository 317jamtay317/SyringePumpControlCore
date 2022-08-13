using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SyringePumpControlCore.Models;

namespace SyringPumpTests.Models;

[TestClass]
public class PumpChainTests
{
    private PumpChain _pumpChain;
    private Mock<IPump> _pump2Mock;
    private Mock<IPump> _pump1Mock;

    [TestInitialize]
    public void Init()
    {
        _pump1Mock = new Mock<IPump>();
        _pump2Mock = new Mock<IPump>();

        _pump1Mock.Setup(x => x.Address).Returns(0);
        _pump2Mock.Setup(x => x.Address).Returns(1);
        
        _pumpChain = new PumpChain(new []{_pump1Mock.Object, _pump2Mock.Object});
    }

    [TestMethod]
    public void ShouldReturnTotalCountOfPumps()
    {
        Assert.AreEqual(2, _pumpChain.TotalPumpsInChain);
    }

    [TestMethod]
    public void ShouldAddAPump()
    {
        var pump3Mock = new Mock<IPump>();
        pump3Mock.Setup(x => x.Address).Returns(2);

        _pumpChain.Add(pump3Mock.Object);
        
        Assert.AreEqual(3, _pumpChain.TotalPumpsInChain);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Add_ShouldThrowExceptionIfSameAddressIsAdded()
    {
        var pump3Mock = new Mock<IPump>();
        
        _pumpChain.Add(pump3Mock.Object);
    }

    [TestMethod]
    public void ShouldRemovePumpFromChain()
    {
        _pumpChain.Remove(1);
        
        Assert.AreEqual(1, _pumpChain.TotalPumpsInChain);
    }

    [TestMethod]
    public void GetPump_ShouldReturnCorrectPump()
    {
        var pump = _pumpChain.GetPump(1);
        
        Assert.AreEqual(1, pump.Address);
    }

    [TestMethod]
    public void ShouldReturnCorrectPump()
    {
        var pump = _pumpChain[1];
        Assert.AreEqual(1, pump.Address);
    }
}