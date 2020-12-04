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

            bool isValid = false;
            List<string> validEyeColors = new List<string>(new string[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"});
            string hgtMatch = "\\d+(in|cm)";
            string hclMatch = "\\#[a-z0-9]{6}";
            string pidMatch = "\\d{9}";

            foreach (KeyValuePair<string, string> field in input.getFields()) {

                switch (field.Key) {

                    case "byr":
                        if (long.Parse(field.Value) >= 1920 && long.Parse(field.Value) <=2002) {
                            isValid = true;
                        }
                        else {
                            isValid = false;
                        }
                        break;

                    case "iyr":
                        if (long.Parse(field.Value) >= 2010 && long.Parse(field.Value) <=2020) {
                            isValid = true;
                        }
                        else {
                            isValid = false;
                        }
                        break;

                    case "eyr":
                        if (long.Parse(field.Value) >= 2020 && long.Parse(field.Value) <=2030) {
                            isValid = true;
                        }
                        else {
                            isValid = false;
                        }
                        break;

                    case "hgt":
                        if (Regex.IsMatch(field.Value, hgtMatch)) {
                            string unit = field.Value.Substring(field.Value.Length - 2, 2);
                            long value = long.Parse(field.Value.Substring(0, field.Value.Length -2));
                            switch (unit) {

                                case "cm":
                                    if (value >= 150 && value <= 192) {
                                        isValid = true;
                                    }
                                    else {
                                        isValid = false;
                                    }
                                    break;
                                
                                case "in":
                                    if (value >= 59 && value <= 76) {
                                        isValid = true;
                                    }
                                    else {
                                        isValid = false;
                                    }
                                    break;

                                default:
                                    isValid = false;
                                    break;

                            }
                        }
                        else {
                            isValid = false;
                        }
                        break;

                    case "hcl":
                        if (Regex.IsMatch(field.Value, hclMatch)) {
                            isValid = true;
                        }
                        else {
                            isValid = false;
                        }
                        break;

                    case "ecl":
                        if (validEyeColors.Contains(field.Value)) {
                            isValid = true;
                        }
                        else {
                            isValid = false;
                        }
                        break;

                    case "pid":
                        if (Regex.IsMatch(field.Value, pidMatch)) {
                            isValid = true;
                        }
                        else {
                            isValid = false;
                        }
                        break;


                    default:
                        break;

                }

            }

            return isValid;

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

            lineReader read = new lineReader();
            resultWriter write = new resultWriter();
            performanceTime timer = new performanceTime();

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

    }

}