using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace adventOfCode2020 {

    class performanceTime {

        public TimeSpan measuredTime(Func<object> functionToBeMeasured) {

            Stopwatch timer = new Stopwatch();

             timer.Start();
             object result = functionToBeMeasured();
             timer.Stop();

             return timer.Elapsed;

        }

    }

}