namespace SimpleWindowsService
{
    using System;
    using System.IO;
    using System.Timers;

    internal class HeartBeat
    {
        private const string Path = "SimpleWindowsServiceLog.txt";
        private readonly Timer _timer;

        public HeartBeat()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(path: Path, contents: lines);
        }

        public void Start() => _timer.Start();

        public void Stop() => _timer.Stop();
    }
}