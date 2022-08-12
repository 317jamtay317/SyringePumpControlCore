using System;
using System.Timers;

namespace SyringePumpControlNetStandard.Models
{
    public class DelayedCommand:IDisposable
    {
        private readonly object[] _parameters;
        private Timer _timer;
        public DelayedCommand(TimeSpan timeSpan, params object[] parameters)
        {
            _parameters = parameters;
            TimeSpan = timeSpan;
            _timer = new Timer(timeSpan.Milliseconds){AutoReset = false};
        }

        public TimeSpan TimeSpan { get; }
        

        public void Start(Action<object[]> callback)
        {
            _timer.Elapsed += (s, e) => callback(_parameters);
            _timer.Start();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}