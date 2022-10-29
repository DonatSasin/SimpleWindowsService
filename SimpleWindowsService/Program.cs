namespace SimpleWindowsService
{
    using System;
    using Topshelf;

    internal static class Program
    {
        private static void Main()
        {
            TopshelfExitCode exitCode = RunService();
            Environment.ExitCode = TopshelfExitCodeToInt(exitCode);
        }

        private static int TopshelfExitCodeToInt(TopshelfExitCode exitCode) => (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());

        private static TopshelfExitCode RunService() =>
            HostFactory.Run(x =>
            {
                x.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(_ => new HeartBeat());
                    s.WhenStarted(heartbeat => heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("AAASimpleWindowsService");
                x.SetDisplayName("AAA Sipmel Windows Service");
                x.SetDescription("This is the simple Widows service");
            });
    }
}