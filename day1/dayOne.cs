using System;
using System.Collections.Generic;

namespace adventOfCode2020
{
    class day1
    {

        private long partOne(List<string> input) {

            int num1 = 0;
            int num2 = 0;
            long result = 0;

            input.Sort();

            foreach (string item in input) {

                if (item != "") {

                    string remainder = (2020 - int.Parse(item)).ToString();

                    if (input.Contains(remainder)) {

                        num1 = int.Parse(item);
                        num2 = int.Parse(remainder);
                        break;

                    }
                
                }

            }

            result = num1 * num2;

            return result;

        }

        private long partTwo(List<string> input) {

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            long result = 0;

            input.Sort();

            foreach (string item in input) {

                if (item != "") {

                    string remainder1 = (2020 - int.Parse(item)).ToString();

                    foreach (string secondItem in input) {

                        if (secondItem != "") {

                            string remainder2 = (int.Parse(remainder1) - int.Parse(secondItem)).ToString();

                            if (input.Contains(remainder2)) {

                                num1 = int.Parse(item);
                                num2 = int.Parse(secondItem);
                                num3 = int.Parse(remainder2);
                                break;

                            }
                        
                        }
                    
                    }
                
                }

                if (num1 != 0) {

                    break;

                }

            }

            result = num1 * num2 * num3;

            return result;

        }

        public void day1Run()
        {

            lineReader read = new lineReader();
            resultWriter write = new resultWriter();
            performanceTime timer = new performanceTime();

            string text = System.IO.File.ReadAllText(@"Day1\inputDay1.txt");
            List<string> items = read.gatherLines(text);

            TimeSpan timer1 = timer.measuredTime(() => partOne(items));
            TimeSpan timer2 = timer.measuredTime(() => partTwo(items));

            long result = partOne(items);
            long resultPartTwo = partTwo(items);

            write.timesTaken.Add(timer1);
            write.timesTaken.Add(timer2);
            write.partResults.Add("part one", result.ToString());
            write.partResults.Add("Part two", resultPartTwo.ToString());

            write.writeResults(1);

        }
    }
}
