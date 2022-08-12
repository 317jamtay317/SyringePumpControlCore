using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SyringePumpControlNetStandard.Models;
using SyringePumpControlNetStandard.Models.Commands;

namespace SyringPumpTests.Models
{
    [TestClass]
    public class PumpTests
    {
        private Mock<IPort> _portMock;
        private Pump _pump;

        [TestInitialize]
        public void Init()
        {
            _portMock = new Mock<IPort>();
            _pump = new Pump(_portMock.Object);
        }

        [TestMethod]
        public void ShouldSendCommandValueToPort()
        {
            var command = new PurgeCommand(1);
            _pump.Send(command);
            _portMock.Verify(x=>x.WriteLine("1PUR\r\n"));
        }

        [TestMethod]
        public void ShouldOpenPortOnSend()
        {
            var command = new PurgeCommand(1);
            _portMock.Setup(x => x.IsOpen).Returns(false);
            _pump.Send(command);
            _portMock.Verify(x=>x.Open(), Times.Once);
        }
        [TestMethod]
        public void ShouldNotOpenPortOnSendIfAlreadyOpen()
        {
            var command = new PurgeCommand(1);
            _portMock.Setup(x => x.IsOpen).Returns(true);
            _pump.Send(command);
            _portMock.Verify(x=>x.Open(), Times.Never);
        }

        [TestMethod]
        public void ShouldDisconnectPortOnSend()
        {
            var command = new PurgeCommand(1);
            _portMock.Setup(x => x.IsOpen).Returns(true);
            _pump.Send(command);
            _portMock.Verify(x=>x.Close(), Times.Once);
        }

        [TestMethod]
        public void Connect_ShouldOpenPort()
        {
            _pump.Connect();
            _portMock.Verify(x=>x.Open(), Times.Once);
        }

        [TestMethod]
        public void Connect_ShouldNotOpenPortIfAlreadyConnected()
        {
            _portMock.Setup(x => x.IsOpen).Returns(true);
            _pump.Connect();
            _portMock.Verify(x=>x.Open(), Times.Never);
        }

        [TestMethod]
        public void Disconnect_ShouldNotCallCloseIfPortIsAlreadyClosed()
        {
            _pump.Disconnect();
            _portMock.Verify(x=>x.Close(), Times.Never);
        }

        [TestMethod]
        public void Disconnect_ShouldClosePort()
        {
            _portMock.Setup(x => x.IsOpen).Returns(true);
            _pump.Disconnect();
            _portMock.Verify(x=>x.Close(), Times.Once); 
        }
    }
}