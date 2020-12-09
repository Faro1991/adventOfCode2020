using System.Collections.Generic;
using System.Linq;

namespace adventOfCode2020 {

    class day9 : dayBase {

        private long preambleSize = 25;

        private bool findPair(long[] input, long targetNumber, long preambleSize, long currentPos) {

            bool result = false;

            long[] searchArray = new long[preambleSize];

            for (long i = 0; i < preambleSize; ++i) {

                searchArray[i] = input[(i + currentPos) - preambleSize];

            }

            foreach (long number in searchArray) {

                long remainder = targetNumber - number;


                if (searchArray.Where(x => x != number).ToArray().Contains(remainder)) {

                    result = true;
                    break;

                }

            }


            return result;

        }
        private long findOddOneOut(List<string> input, long preambleSize) {

            long result = 0;

            List<long> longs = new List<long>();

            foreach (string element in input) {

                if (element != "") {

                    longs.Add(long.Parse(element));

                }

            }

            long[] preamble = new long[longs.Count];

            longs.CopyTo(preamble);

            long currentPos = preambleSize;

            while (currentPos < preamble.Length) {

                long targetNumber = preamble[currentPos];

                bool pairFound = findPair(preamble, targetNumber, preambleSize, currentPos);

                if (!pairFound) {

                    result = preamble[currentPos];
                    break;

                }

                ++currentPos;

            }

            return result;

        }

        private long findEncryptionWeakness(List<string> input, long targetNumber, long preambleSize) {

            long result = 0;

            List<long> longs = new List<long>();

            foreach (string element in input) {

                if (element != "") {

                    longs.Add(long.Parse(element));

                }

            }

            long[] tmp = new long[longs.Count];

            longs.CopyTo(tmp);

            List<long> searchList = new List<long>(tmp);

            longs.Sort();

            int targetNumberIndex = longs.IndexOf(targetNumber);

            longs.RemoveRange(targetNumberIndex, (longs.Count - targetNumberIndex));

            longs.Reverse();

            foreach (long possibleStart in longs) {

                int startingPoint = searchList.IndexOf(possibleStart);

                if (startingPoint >= 1 && startingPoint < searchList.Count) {

                    long remainder = targetNumber - possibleStart;
                    int steps = 1;

                    List<long> numbers = new List<long>();
                    numbers.Add(possibleStart);

                    while (remainder > 0) {

                        int pos = startingPoint - steps;

                        if (pos > 0) {

                            long substractor = searchList[pos];

                            remainder -= substractor;
                            numbers.Add(substractor);
                            ++steps;

                        }
                        else {

                            remainder = -1;

                        }

                    }
                    if (remainder == 0) {

                        result = numbers.Max() + numbers.Min();
                        break;

                    }

                }

            }

            return result;

        }
        public override long partOne(List<string> input)
        {

            long result = 0;

            result = findOddOneOut(input, this.preambleSize);

            return result;
        
        }

        public override long partTwo(List<string> input)
        {

            long result = 0;

            result = findEncryptionWeakness(input, partOne(input), this.preambleSize);

            return result;
        
        }

    }

}