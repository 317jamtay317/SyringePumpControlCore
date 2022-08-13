using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyringePumpControlCore.Extensions;
using SyringePumpControlCore.Models;
using SyringePumpControlCore.Models.CommandConstants;

namespace SyringPumpTests.Models;

[TestClass]
public class ToCommandExtensionTests
{
    [TestMethod]
    public void UnitRateShouldReturnCorrectCommandValue()
    {
        var unitRate = RateUnits.MicrolitersPerHour;
        Assert.AreEqual(UnitRateConversions.MicrolitersPerHour, unitRate.ToCommandString());
        
        unitRate = RateUnits.MicrolitersPerMinutes;
        Assert.AreEqual(UnitRateConversions.MicrolitersPerMinute, unitRate.ToCommandString());
        
        unitRate = RateUnits.MilliLitersPerHour;
        Assert.AreEqual(UnitRateConversions.MillilitersPerHour, unitRate.ToCommandString());
        
        unitRate = RateUnits.MillilitersPerMinute;
        Assert.AreEqual(UnitRateConversions.MilliLiterPerMinute, unitRate.ToCommandString());
    }

    [TestMethod]
    public void UnitShouldReturnCorrectCommandString()
    {
        var unit = Units.Microliters;
        Assert.AreEqual(UnitConversions.Microliters, unit.ToCommandString());
        
        unit = Units.Milliliters;
        Assert.AreEqual(UnitConversions.Milliliters, unit.ToCommandString());
    }

    [TestMethod]
    public void PumpDirectionShouldReturnCorrectCommandString()
    {
        var pumpDirection = PumpDirection.Infuse;
        Assert.AreEqual(PumpDirectionConversions.Infuse, pumpDirection.ToCommandString());
        
        pumpDirection = PumpDirection.Withdraw;
        Assert.AreEqual(PumpDirectionConversions.Withdraw, pumpDirection.ToCommandString());
    }
}