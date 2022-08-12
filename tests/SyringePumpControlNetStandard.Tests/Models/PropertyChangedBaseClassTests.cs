using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyringePumpControlNetStandard.Models;

namespace SyringPumpTests.Models;

[TestClass]
public class PropertyChangedBaseClassTests
{
    private Model _model;

    [TestInitialize]
    public void Init()
    {
        _model = new Model();
    }

    [TestMethod]
    public void ShouldCallOnPropertyChanged()
    {
        var fired = false;
        _model.PropertyChanged += (_, _) => fired = true;

        _model.FirstName = "Test";
        
        Assert.IsTrue(fired);
    }

    [TestMethod]
    public void ShouldCallOnPropertyChangedOnUpdate()
    {
        _model.FirstName = "Test";
        var fired = false;
        _model.PropertyChanged += (_, _) => fired = true;

        _model.FirstName = "Something else";
        
        Assert.IsTrue(fired);
    }

    [TestMethod]
    public void ShouldReturnCorrectValue()
    {
        _model.FirstName = "Test";
        Assert.AreEqual("Test", _model.FirstName);
    }
}

class Model : PropertyChangedBaseClass
{
    public string FirstName
    {
        get => GetValue<string>();
        set => SetValue(value);
    }
}