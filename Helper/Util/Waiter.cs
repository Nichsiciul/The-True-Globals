using UiHelper.Logging;
using System;
using System.Configuration;

namespace Util
{
    public abstract class Waiter
    {
        public long MillisecondsToPause { get; set; }
        public long SecondsToWait { get; set; }

        ///
        public Waiter(int secondsToWait, long millisecondsToPause)
        {
            this.SecondsToWait = secondsToWait;
            this.MillisecondsToPause = millisecondsToPause;
        }

        /// <summary>
        /// Wait for a condition to be met.
        /// </summary>
        /// <returns>true if the condition has met</returns>
        public bool WaitForConditionToBeMet()
        {
            Logger.Instance.Information("Waiting {SecondsToWait}s for a condition to be met", SecondsToWait);
            var start = DateTime.Now;

            int tries = 0;
            while ((DateTime.Now - start).TotalMilliseconds < SecondsToWait * 1000)
            {
                tries++;
                try
                {
                    if (CheckCondition())
                    {
                        Logger.Instance.Information("Condition met after {Tries} retries / {TotalSeconds} seconds.", tries, (DateTime.Now - start).TotalSeconds);
                        return true;
                    }
                }
                catch { }

                Sleeper.Sleep(MillisecondsToPause, true);
            }

            Logger.Instance.Warning("Condition not met after {Tries} retries and {TotalSeconds}s waiting time with {MillisecondsToPause} milliseconds wait in between - time out.", 
                                     tries, (DateTime.Now - start).TotalSeconds, MillisecondsToPause);
            return false;
        }

        public abstract bool CheckCondition();
    }
}
