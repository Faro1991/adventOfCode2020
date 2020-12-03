using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace adventOfCode2020
{

    class day2
    {

        private int partOne(List<string> input) {

            int counter = 0;

            foreach (string line in input) {

                if (line != "") {

                    string requirement = line.Split(":")[0];
                    string pass = line.Split(":")[1].TrimStart(' ');

                    List<Match> allowedNumbers = new List<Match>(Regex.Matches(requirement, "\\d+", RegexOptions.Singleline));
                    Match requiredChar = Regex.Match(requirement, "[a-zA-Z]");

                    int numOfOccurences = Regex.Matches(pass, requiredChar.ToString()).Count;

                    if (numOfOccurences >= int.Parse(allowedNumbers[0].ToString()) && numOfOccurences <= int.Parse(allowedNumbers[1].ToString())) {

                        ++counter;

                    }    

                }          

            }

            return counter;

        }

        private int partTwo(List<string> input){

            int counter = 0;

            foreach (string line in input) {

                if (line != "") {

                    string requirement = line.Split(":")[0];
                    string pass = line.Split(":")[1].TrimStart(' ');

                    List<Match> allowedNumbers = new List<Match>(Regex.Matches(requirement, "\\d+", RegexOptions.Singleline));
                    Match requiredChar = Regex.Match(requirement, "[a-zA-Z]");

                    int pos1 = int.Parse(allowedNumbers[0].ToString()) - 1;
                    int pos2 = int.Parse(allowedNumbers[1].ToString()) - 1;

                    if (pos1 <= pass.Length && pos2 <= pass.Length) {

                        string cmpString = "";
                        cmpString += pass[pos1];
                        cmpString += pass[pos2];

                        int numOfOccurences = Regex.Matches(cmpString, requiredChar.ToString()).Count;
                        if (numOfOccurences == 1) {

                            ++counter;

                        }

                    }

                }          

            }

            return counter;

        }

        public void day2Run() {

            lineReader read = new lineReader();
            resultWriter write = new resultWriter();
            performanceTime timer = new performanceTime();

            string text = System.IO.File.ReadAllText(@"day2\inputDay2.txt");
            List<string> items = read.gatherLines(text);

            TimeSpan timer1 = timer.measuredTime(() => partOne(items));
            TimeSpan timer2 = timer.measuredTime(() => partTwo(items));

            int result = partOne(items);
            int resultPartTwo = partTwo(items);

            write.timesTaken.Add(timer1);
            write.timesTaken.Add(timer2);
            write.partResults.Add("part one", result.ToString());
            write.partResults.Add("Part two", resultPartTwo.ToString());


            write.writeResults(2);

        }

    }

}