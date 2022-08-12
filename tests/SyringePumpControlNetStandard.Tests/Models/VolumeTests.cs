using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyringePumpControlNetStandard.Models;

namespace SyringPumpTests.Models;

[TestClass]
public class VolumeTests
{

    [TestMethod]
    public void EqualsShouldReturnTrueWhenSameValues()
    {
        var volume = new Volume(3, Units.Microliters);
        var volume2 = new Volume(3, Units.Microliters);
        
        Assert.IsTrue(volume.Equals(volume2));
    }

    [TestMethod]
    public void ShouldCreateCorrectVolumeFromString()
    {
        var expectedValue = new Volume(3, Units.Milliliters);
        Volume actualValue = "3ml";
        
        Assert.IsTrue(expectedValue.Equals(actualValue));
    }

    [TestMethod]
    public void InvalidStringShouldReturnDefault()
    {
        var expectedValue = Volume.Default();
        Volume actualValue = "ml";
        
        Assert.IsTrue(expectedValue.Equals(actualValue));
    }
}