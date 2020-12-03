using System;
using System.Collections.Generic;

namespace adventOfCode2020
{
    
    public abstract class dayBase {

        public abstract long partOne(List<string> input);
        public abstract long partTwo(List<string> input);

        public virtual void dayRun(int day, string input) {

            lineReader read = new lineReader();
            resultWriter write = new resultWriter();
            performanceTime timer = new performanceTime();

            string text = System.IO.File.ReadAllText(input);
            List<string> items = read.gatherLines(text);

            TimeSpan timer1 = timer.measuredTime(() => partOne(items));
            TimeSpan timer2 = timer.measuredTime(() => partTwo(items));

            long result = partOne(items);
            long resultPartTwo = partTwo(items);

            write.timesTaken.Add(timer1);
            write.timesTaken.Add(timer2);
            write.partResults.Add("part one", result.ToString());
            write.partResults.Add("Part two", resultPartTwo.ToString());

            write.writeResults(day);

        }

    }

}