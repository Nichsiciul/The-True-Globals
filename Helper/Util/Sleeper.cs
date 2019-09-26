using UiHelper.Logging;
using System;
using System.Threading;


namespace Util
{
    public class Sleeper
    {
	    private static long SLEPT_TOTAL = 0;

        private Sleeper()
        {
            // no instantiation allowed
        }

        /**
         * please use this only to avoid log spamming, ie. with Waiters
         */
        public static void Sleep(long ms, bool forceNoLog)
        {
            if (ms < 0)
            {
                Logger.Instance.Warning("I won't sleep - ms is negative! {Ms}", ms);
                return;
            }

            if (!forceNoLog)
            {
                throw new ThreadInterruptedException("forceNoLog has to be true!");
            }

            try
            {
                Thread.Sleep((int)ms);
                SLEPT_TOTAL += ms;
            }
            catch (ThreadInterruptedException e)
            {
                Logger.Instance.Warning(e, "Error while sleeping");
            }

        }

        public static void Sleep(long ms, SleepReason reason)
        {
            if (ms > 10 * 1000)
            {
                Logger.Instance.Information("Sleeping for {Ms}ms, until {V}, because: {Reason}", ms, new DateTime().AddMilliseconds(ms).ToString(), reason);
            }
            else
            {
                Logger.Instance.Information("Sleeping for {Ms}ms, because: {Reason}", ms, reason);
            }
            Sleep(ms, true);
        }

        public static void Sleep(int seconds, SleepReason reason)
        {
            Sleep(seconds * 1000L, reason);
        }

        public static long GetSleptTotalAndReset()
        {
            long returnValue = SLEPT_TOTAL;
            SLEPT_TOTAL = 0;
            return returnValue;
        }
    }
}
