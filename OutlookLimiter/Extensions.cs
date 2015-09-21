using System.Diagnostics;

namespace OutlookLimiter
{
    public static class Extensions
    {
        public static void Stop(this Process p)
        {
            if (p.Running())
            {
                p.CloseMainWindow();
                p.WaitForExit(2000);
            }
        }

        public static bool Running(this Process p)
        {
            return p != null && !p.HasExited;
        }
    }
}