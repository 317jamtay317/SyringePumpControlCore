using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyringePumpControlNetStandard.Models;

namespace SyringPumpTests.Models;

[TestClass]
public class DelayedCommandTests
{

    [TestMethod]
    public void ShouldCallCallbackAfterDelay()
    {
        var timeSpan = TimeSpan.FromMilliseconds(1);
        var delayCommand = new DelayedCommand(timeSpan);
        var fired = false;
        
        delayCommand.Start((s)=>fired=true);
        Assert.IsFalse(fired);
        Thread.Sleep(10);
        
        Assert.IsTrue(fired);
    }

}