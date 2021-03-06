using System;
using System.Collections.Generic;

namespace adventOfCode2020 {
    
    class day3 :dayBase {

        private List<string> buildFullPath(List<string> input) {

            List<string> fullPath = new List<string>();

            foreach (string item in input) {

                string pathText = "";

                for (int j = 0; j <= input.Count; ++j) {

                    pathText += item;

                }
                
                fullPath.Add(pathText);

            }

            return fullPath;

        }

        public override long partOne(List<string> input) {

            int pos = 0;
            long counter = 0;

            foreach (string item in input) {

                if (pos < item.Length) {

                    if (item[pos] == '#') {

                        ++counter;

                    }
                    pos += 3;

                }

            }

            return counter;

        }

        public override long partTwo(List<string> input) {

            return 0;

        }
        public long partTwo(List<string> input, int stepdown, int stepright) {

            int pos = 0;
            long counter = 0;

            foreach (string item in input) {

                if (input.IndexOf(item) % stepdown == 0) {

                    if (pos < item.Length) {

                        if (item[pos] == '#') {

                            ++counter;

                        }
                        pos += stepright;

                    }

                }

            }

            return counter;

        }

        public override void dayRun(int day, string input) {

            lineReader read = new lineReader();
            resultWriter write = new resultWriter();
            performanceTime timer = new performanceTime();

            string text = System.IO.File.ReadAllText(input);
            List<string> items = read.gatherLines(text);
            List<string> fullPath = buildFullPath(items);

            TimeSpan timer1 = timer.measuredTime(() => partOne(fullPath));
            TimeSpan timer2 = timer.measuredTime(() => partTwo(fullPath, 1, 1));
            long result = this.partOne(fullPath);
            long resultPartTwo = this.partTwo(fullPath, 1, 1) * partTwo(fullPath, 1, 3) * partTwo(fullPath, 1, 5) * partTwo(fullPath, 1, 7) * partTwo(fullPath, 2, 1);


            write.timesTaken.Add(timer1);
            write.timesTaken.Add(timer2);
            write.partResults.Add("part one", result.ToString());
            write.partResults.Add("Part two", resultPartTwo.ToString());


            write.writeResults(day);

        }

    }

}