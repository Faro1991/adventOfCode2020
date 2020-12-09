using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading;
using System;

namespace adventOfCode2020 {

    class day8 : dayBase {

        private long computeInstructions(List<string> input, bool breakonLoop) {

            long result = 0;
            long accumulator = 0;
            int currentPos = 0;

            HashSet<string> completedInstructions = new HashSet<string>();

            while (currentPos < input.Count) {

                string command = input[currentPos];

                if (completedInstructions.Contains(command + ";" + currentPos)) {

                    string lastCommand = completedInstructions.Last();
                    result = accumulator;
                    break;

                }

                completedInstructions.Add(command + ";" + currentPos);

                if (command != "") {

                    string instruction = Regex.Match(command, @"\w+").Value;
                    int amount = int.Parse(Regex.Match(command, @"[+-]\d+").Value);
                    
                    switch (instruction) {

                        case "acc":
                            accumulator += amount;
                            ++currentPos;
                            break;

                        case "jmp":
                            currentPos += amount;
                            break;

                        default:
                            ++currentPos;
                            break;

                    }

                }

            }

            if (breakonLoop || currentPos == (input.Count - 1) ){

                result = accumulator;
            
            }
            else {

                result = -1;

            }

            return result;

        }

        private HashSet<string> listCommandsUntilRepitition(List<string> input) {

            long accumulator = 0;
            int currentPos = 0;

            HashSet<string> completedInstructions = new HashSet<string>();

            string command = input[currentPos];

            while (!completedInstructions.Contains(command + ";" + currentPos)) {

                if (command != "") {
                    
                    completedInstructions.Add(command + ";" + currentPos);

                }

                string instruction = Regex.Match(command, @"\w+").Value;
                int amount = int.Parse(Regex.Match(command, @"[+-]\d+").Value);
                
                switch (instruction) {

                    case "acc":
                        accumulator += amount;
                        ++currentPos;
                        break;

                    case "jmp":
                        currentPos += amount;
                        break;

                    default:
                        ++currentPos;
                        break;

                }

                command = input[currentPos];

            }

            return completedInstructions;

        }

        private List<string> listCommandsWithPosition(List<string> input) {

            List<string> result = new List<string>();

            int currentPos = 0;

            foreach (string command in input) {

                if (command != "") {

                    result.Add(command + ";" + currentPos);

                }
                ++currentPos;

            }

            return result;

        }

        
        public override long partOne(List<string> input)
        {

            long result = computeInstructions(input, true);

            return result;

        }

        public override long partTwo(List<string> input)
        {

            long result = 0;

            string newInstruction = "";

            List<string> positionedInput = listCommandsWithPosition(input).Where(x => x.Contains("jmp") || x.Contains("nop")).ToList();

            string[] inputCopy = new string[input.Count];

            List<List<string>> variations = new List<List<string>>();

            foreach (string candidate in positionedInput) {

                
                input.CopyTo(inputCopy);

                string instruction = Regex.Match(candidate, @"\w+").Value;
                string amount = Regex.Match(candidate, @"[+-]\d+").Value;
                int position = int.Parse(Regex.Match(candidate, @"(?<=;)\d+").Value);


                switch (instruction) {

                    case "jmp":
                        instruction = "nop";
                        break;

                    case "nop":
                        instruction = "jmp";
                        break;

                    default:
                        break;

                }

                newInstruction = instruction + " " + amount;

                inputCopy[position] = newInstruction;

                variations.Add(inputCopy.ToList());

                inputCopy = new string[input.Count];

            }

            foreach (List<string> variation in variations) {

                result = computeInstructions(variation, false);

                if (result > 0) {

                    break;

                }

            }

            if (result < 0) {

                throw new IndexOutOfRangeException("result has to be larger than zero!");

            }

            return result;

        }

    }

}