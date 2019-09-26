using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class FuncWaiter : Waiter
    {
        private readonly Func<bool> condition;

        public FuncWaiter(Func<bool> condition, int secondsToWait, long millisecondsToPause) : base(secondsToWait, millisecondsToPause)
        {
            this.condition = condition;
        }

        public FuncWaiter(Func<bool> condition, int secondsToWait) : this(condition, secondsToWait, 500)
        {
        }


        public FuncWaiter(Func<bool> condition) : this(condition, 15, 1000)
        {
        }

        public static bool WaitFor(Func<bool> condition)
        {
            return new FuncWaiter(condition).WaitForConditionToBeMet();
        }

        public static bool WaitFor(Func<bool> condition, int secondsToWait, long millisecondsToPause)
        {
            return new FuncWaiter(condition, secondsToWait, millisecondsToPause).WaitForConditionToBeMet();
        }


        public override bool CheckCondition()
        {
            return this.condition();
        }
    }
}
