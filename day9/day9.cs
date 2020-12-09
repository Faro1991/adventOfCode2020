using System.Collections.Generic;
using System.Linq;

namespace adventOfCode2020 {

    class day9 : dayBase {

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
        public override long partOne(List<string> input)
        {

            long result = 0;

            result = findOddOneOut(input, 25);

            return result;
        
        }

        public override long partTwo(List<string> input)
        {

            long result = 0;



            return result;
        
        }

    }

}