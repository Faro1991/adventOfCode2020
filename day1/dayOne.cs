using System;
using System.Collections.Generic;

namespace adventOfCode2020 {
    class day1 : dayBase {

        public override long partOne(List<string> input) {

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

        public override long partTwo(List<string> input) {

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

    }
}
