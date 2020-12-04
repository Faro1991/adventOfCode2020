using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace adventOfCode2020 {

    class day4 : dayBase {


        private List<passport> gatherPassports(string[] input) {

            List<passport> result = new List<passport>();
            long currentLine = 0;
            passport newPass = new passport();

            while (currentLine < input.Length) {

                if (input[currentLine] != "") {

                    string[] lineArray = input[currentLine].Split(" ");
                    foreach (string data in lineArray) {

                        string[] kvp = data.Split(":");
                        newPass.addPassportEntry(kvp[0], kvp[1]);

                    }

                }
                else {

                    result.Add(newPass);
                    newPass = new passport();

                }

                ++currentLine;

            }

            return result;

        }

        private bool validateFields(passport input) {


            bool hasError = false;
            List<string> validEyeColors = new List<string>(new string[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"});
            string hgtMatch = @"^\d+(in|cm)$";
            string hclMatch = @"^\#[a-f0-9]{6}$";
            string pidMatch = @"^\d{9}$";

            Dictionary<string, string> values = input.getFields();

            foreach (KeyValuePair<string, string> field in values) {

                long.TryParse(field.Value, out long fieldVal);

                switch (field.Key) {

                    case "byr":
                        
                        if (!(fieldVal >= 1920 && fieldVal <=2002 && field.Value.Length == 4)) {
                            hasError = true;
                        }
                        break;

                    case "iyr":
                        if (!(fieldVal >= 2010 && fieldVal <=2020 && field.Value.Length == 4)) {
                            hasError = true;
                        }
                        break;

                    case "eyr":
                        if (!(fieldVal >= 2020 && fieldVal <=2030 && field.Value.Length == 4)) {
                            hasError = true;
                        }
                        break;

                    case "hgt":
                        Match hgtSuccess = Regex.Match(field.Value, hgtMatch);
                        if (hgtSuccess.Success) {
                            string unit = field.Value.Substring(field.Value.Length - 2, 2);
                            long value = long.Parse(field.Value.Substring(0, field.Value.Length -2));
                            switch (unit) {

                                case "cm":
                                    if (!(value >= 150 && value <= 192)) {
                                        hasError = true;
                                    }
                                    break;
                                
                                case "in":
                                    if (!(value >= 59 && value <= 76)) {
                                        hasError = true;
                                    }
                                    break;

                                default:
                                    hasError = true;
                                    break;

                            }
                        }
                        break;

                    case "hcl":
                        Match hclSuccess = Regex.Match(field.Value, hclMatch);
                        if (!hclSuccess.Success) {
                            hasError = true;
                        }
                        break;

                    case "ecl":
                        List<string> amountOfEcl = validEyeColors.FindAll(x => (x == field.Value));
                        bool hasValidEcl = validEyeColors.Contains(field.Value);
                        if (!hasValidEcl || amountOfEcl.Count != 1) {
                            hasError = true;
                        }
                        break;

                    case "pid":
                        Match pidSuccess = Regex.Match(field.Value, pidMatch);
                        if (!pidSuccess.Success) {
                            hasError = true;
                        }
                        break;

                    case "cid":
                        break;

                    default:
                        hasError = true;
                        break;

                }

                if (hasError) {

                    return false;

                }

            }

            return true;

        }       

        public override long partOne(List<string> input)
        {
            throw new System.NotImplementedException();
        }

        public override long partTwo(List<string> input)
        {
            throw new System.NotImplementedException();
        }

        public long partOne(List<passport> input, List<string> necessaryFields) {

            List<passport> validPasses = new List<passport>();

            foreach (passport pass in input) {

                bool allPresent = true;

                foreach (string field in necessaryFields) {

                    if (!pass.getFields().ContainsKey(field)) {

                        allPresent = false;

                    }

                }

                if (allPresent) {

                    validPasses.Add(pass);

                }

            }

            return validPasses.Count;

        }

        public long partTwo(List<passport> input, List<string> necessaryFields) {

            List<passport> validPasses = new List<passport>();

            foreach (passport pass in input) {

                bool allPresent = true;
                bool passValid = true;

                foreach (string field in necessaryFields) {

                    if (!pass.getFields().ContainsKey(field)) {

                        allPresent = false;

                    }

                }

                if (allPresent) {

                    passValid = validateFields(pass);

                }
                else {

                    passValid = false;

                }

                if (passValid) {

                    validPasses.Add(pass);

                }

            }

            return validPasses.Count;

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

                List<passport> passportData = gatherPassports(lines);

                string[] necessaryFields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

                TimeSpan timer1 = timer.measuredTime(() => partOne(passportData,new List<string>(necessaryFields)));
                TimeSpan timer2 = timer.measuredTime(() => partTwo(passportData,new List<string>(necessaryFields)));

                long result = partOne(passportData,new List<string>(necessaryFields));
                long resultPartTwo = partTwo(passportData,new List<string>(necessaryFields));

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