using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public sealed class SleepReason : ISleepReason
    {
        // wait because ...
        public static readonly SleepReason TIME = new SleepReason("an event should happen after sleeping");
        public static readonly SleepReason PROCESSING_EVENT = new SleepReason("event has to be processed");
        public static readonly SleepReason AUTOCOMPLETION = new SleepReason("autocompletion has to be triggered");
        public static readonly SleepReason UI = new SleepReason("ui has to render");

        private readonly String Value;

        private SleepReason(String value)
        {
            this.Value = value;
        }

        public String GetReason()
        {
            return Value;
        }
    }
}
