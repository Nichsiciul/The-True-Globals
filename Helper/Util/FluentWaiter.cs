using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class FluentWaiter<T> : Waiter
    {
        private readonly Predicate<T> condition;
        private readonly T instance;

        public FluentWaiter(Predicate<T> condition, T instance, int secondsToWait, long millisecondsToPause) : base(secondsToWait, millisecondsToPause)
        {
            this.condition = condition;
            this.instance = instance;
        }

        public FluentWaiter(Predicate<T> condition, T instance, int secondsToWait) : this(condition, instance, secondsToWait, 1)
        {
        }


        public FluentWaiter(Predicate<T> condition, T instance) : this(condition, instance, 3, 1)
        {
        }



        public override bool CheckCondition()
        {
            return this.condition(this.instance);
        }
    }
}
