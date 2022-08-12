using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Text;

namespace SyringePumpControlNetStandard.Models
{
    public class Port : IPort, IDisposable
    {
        private SerialPort _port = new SerialPort();
        public IEnumerable<string> GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        public object GetLifetimeService()
        {
            return _port.GetLifetimeService();
        }

        public object InitializeLifetimeService()
        {
            return _port.InitializeLifetimeService();
        }

        public void Dispose()
        {
            if (_port.IsOpen)
            {
                _port.Close();
            }
            _port.Dispose();
        }

        public IContainer Container => _port.Container;

        public ISite Site
        {
            get => _port.Site;
            set => _port.Site = value;
        }

        public event EventHandler Disposed
        {
            add => _port.Disposed += value;
            remove => _port.Disposed -= value;
        }

        public void Close()
        {
            _port.Close();
        }

        public void DiscardInBuffer()
        {
            _port.DiscardInBuffer();
        }

        public void DiscardOutBuffer()
        {
            _port.DiscardOutBuffer();
        }

        public void Open()
        {
            _port.Open();
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return _port.Read(buffer, offset, count);
        }

        public int Read(char[] buffer, int offset, int count)
        {
            return _port.Read(buffer, offset, count);
        }

        public int ReadByte()
        {
            return _port.ReadByte();
        }

        public int ReadChar()
        {
            return _port.ReadChar();
        }

        public string ReadExisting()
        {
            return _port.ReadExisting();
        }

        public string ReadLine()
        {
            return _port.ReadLine();
        }

        public string ReadTo(string value)
        {
            return _port.ReadTo(value);
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            _port.Write(buffer, offset, count);
        }

        public void Write(char[] buffer, int offset, int count)
        {
            _port.Write(buffer, offset, count);
        }

        public void Write(string text)
        {
            _port.Write(text);
        }

        public void WriteLine(string text)
        {
            _port.WriteLine(text);
        }

        public Stream BaseStream => _port.BaseStream;

        public int BaudRate
        {
            get => _port.BaudRate;
            set => _port.BaudRate = value;
        }

        public bool BreakState
        {
            get => _port.BreakState;
            set => _port.BreakState = value;
        }

        public int BytesToRead => _port.BytesToRead;

        public int BytesToWrite => _port.BytesToWrite;

        public bool CDHolding => _port.CDHolding;

        public bool CtsHolding => _port.CtsHolding;

        public int DataBits
        {
            get => _port.DataBits;
            set => _port.DataBits = value;
        }

        public bool DiscardNull
        {
            get => _port.DiscardNull;
            set => _port.DiscardNull = value;
        }

        public bool DsrHolding => _port.DsrHolding;

        public bool DtrEnable
        {
            get => _port.DtrEnable;
            set => _port.DtrEnable = value;
        }

        public Encoding Encoding
        {
            get => _port.Encoding;
            set => _port.Encoding = value;
        }

        public Handshake Handshake
        {
            get => _port.Handshake;
            set => _port.Handshake = value;
        }

        public bool IsOpen => _port.IsOpen;

        public string NewLine
        {
            get => _port.NewLine;
            set => _port.NewLine = value;
        }

        public Parity Parity
        {
            get => _port.Parity;
            set => _port.Parity = value;
        }

        public byte ParityReplace
        {
            get => _port.ParityReplace;
            set => _port.ParityReplace = value;
        }

        public string PortName
        {
            get => _port.PortName;
            set => _port.PortName = value;
        }

        public int ReadBufferSize
        {
            get => _port.ReadBufferSize;
            set => _port.ReadBufferSize = value;
        }

        public int ReadTimeout
        {
            get => _port.ReadTimeout;
            set => _port.ReadTimeout = value;
        }

        public int ReceivedBytesThreshold
        {
            get => _port.ReceivedBytesThreshold;
            set => _port.ReceivedBytesThreshold = value;
        }

        public bool RtsEnable
        {
            get => _port.RtsEnable;
            set => _port.RtsEnable = value;
        }

        public StopBits StopBits
        {
            get => _port.StopBits;
            set => _port.StopBits = value;
        }

        public int WriteBufferSize
        {
            get => _port.WriteBufferSize;
            set => _port.WriteBufferSize = value;
        }

        public int WriteTimeout
        {
            get => _port.WriteTimeout;
            set => _port.WriteTimeout = value;
        }

        public event SerialDataReceivedEventHandler DataReceived
        {
            add => _port.DataReceived += value;
            remove => _port.DataReceived -= value;
        }

        public event SerialErrorReceivedEventHandler ErrorReceived
        {
            add => _port.ErrorReceived += value;
            remove => _port.ErrorReceived -= value;
        }

        public event SerialPinChangedEventHandler PinChanged
        {
            add => _port.PinChanged += value;
            remove => _port.PinChanged -= value;
        }
    }
}