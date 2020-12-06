using System;
using System.Linq;
using System.Collections.Generic;

namespace adventOfCode2020 {

    class day6 : dayBase {

        private List<string> gatherAnswersPerGroup(string[] input) {

            List<string> result = new List<string>();
            HashSet<string> answers = new HashSet<string>();
            long currentLine = 0;

            while (currentLine < input.Length) {

                if (input[currentLine] != "" && input[currentLine] != "\r") {

                    char[] lineSplit = input[currentLine].ToCharArray();

                    foreach (char answer in lineSplit) {

                        answers.Add(answer.ToString());

                    }

                }
                else {


                    result.Add(string.Join("", answers));
                    answers.Clear();

                }

                ++currentLine;

            }

            return result;

        }

        private List<string> gatherCommonAnswersPerGroup(string[] input) {

            List<string> result = new List<string>();
            long currentLine = 0;
            List<string> answers = new List<string>();
            string commonAnswersPerGroup = "";
            
            while (currentLine < input.Length) {

                if (input[currentLine] != "" && input[currentLine] != "\r") {

                    answers.Add(input[currentLine].ToLower());

                }
                else {

                    commonAnswersPerGroup = answers[0];
                    answers.RemoveAt(0);

                    if (answers.Count > 0) {


                        foreach (string answer in answers) {

                            char[] commonAnswers = answer.Intersect<char>(commonAnswersPerGroup).ToArray();
                            commonAnswersPerGroup = string.Join("", commonAnswers);

                        }
                    
                    }


                    result.Add(commonAnswersPerGroup);
                    answers.Clear();
                    commonAnswersPerGroup = "";

                }

                ++currentLine;

            }

            return result;

        }

        public override long partOne(List<string> input)
        {
            
            long result = 0;

            foreach (string answers in input) {

                result += answers.Length;

            }

            return result;

        }

        public override long partTwo(List<string> input)
        {
            
            long result = 0;

            foreach (string answers in input) {

                result += answers.Length;

            }

            return result;

        }

        public override void dayRun(int day, string input) {

            if (!System.IO.Directory.Exists("day" + day)) {

                System.IO.Directory.CreateDirectory("day" + day);

            }

            if (!System.IO.File.Exists(input)) {

                getInput(day);

            }

            lineReader read = new lineReader();
            resultWriter write = new resultWriter();
            performanceTime timer = new performanceTime();

            try {

                string text = System.IO.File.ReadAllText(input);
                string[] lines = text.Split("\n");

                List<string> answersPerGroup = gatherAnswersPerGroup(lines);
                List<string> commonAnswersPerGroup = gatherCommonAnswersPerGroup(lines);

                TimeSpan timer1 = timer.measuredTime(() => partOne(answersPerGroup));
                TimeSpan timer2 = timer.measuredTime(() => partTwo(commonAnswersPerGroup));

                long result = partOne(answersPerGroup);
                long resultPartTwo = partTwo(commonAnswersPerGroup);

                write.timesTaken.Add(timer1);
                write.timesTaken.Add(timer2);
                write.partResults.Add("part one", result.ToString());
                write.partResults.Add("Part two", resultPartTwo.ToString());

                write.writeResults(day);
            
            }
            catch (System.IO.FileNotFoundException e) {

                Console.WriteLine("could not find file, skipping day " + day);
                Console.WriteLine(e);

            }

        }

    }

}