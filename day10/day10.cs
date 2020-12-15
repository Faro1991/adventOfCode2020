using System.Collections.Generic;
using System.Linq;

namespace adventOfCode2020 {

    class day10 : dayBase {

        private long calculateJolts(List<long> input, long maxJoltRating, long [] validJumps) {

            long result = 0;

            long lastVal = 0;
            long difference = 0;

            long ones = 0;
            long threes = 0;

            foreach (long jolt in input) {

                difference = jolt - lastVal;

                if (validJumps.Contains(difference)) {

                    lastVal = jolt;
                    switch (difference) {

                        case 1:
                            ++ones;
                            break;

                        case 3:
                            ++threes;
                            break;

                        default:
                            break;

                    }

                }
                else {

                    throw new System.Exception("difference outside defined bounds!");

                }

            }

            if (maxJoltRating - lastVal == 3) {

                ++threes;

            }

            result = ones * threes;

            return result;

        }

        private List<string> buildPaths(List<long> input, long[] validJumps, string pathSoFar, List<string> paths, int depth) {

            HashSet<string> result = new HashSet<string>();
            pathSoFar += input.First() + ",";

            if (input.Count > 1) {

                List<long> possibleTargets = new List<long>();

                foreach (long jump in validJumps) {

                    long dest = input.First() + jump;

                    if (input.Contains(dest)) {

                        possibleTargets.Add(dest);

                    }

                }

                foreach (long target in possibleTargets) {

                    for (int i = 1; i < possibleTargets.Count; ++i) {

                        paths.Add(pathSoFar);

                    }

                    result.UnionWith(buildPaths(input.Where(x => x >= target).ToList(), validJumps, pathSoFar, paths, depth));


                }

                

            }
            else {

                string lastInput = input.Last().ToString();

                depth = paths.IndexOf(paths.Find(x => x.Split(',').Last() != lastInput));

                paths[depth] += pathSoFar.TrimEnd(',');

                result = paths.ToHashSet();

            }

            result.RemoveWhere(x => x.Split(',').Last() != input.Last().ToString());

            return result.ToList();

        }
        

        public override long partOne(List<string> input)
        {

            long result = 0;

            List<long> adapters = new List<long>();

            foreach (string item in input) {

                if (item != "") {

                    adapters.Add(long.Parse(item));

                }

            }

            adapters.Sort();

            long maxJoltRating = adapters.Max() + 3;


            try {

                result = calculateJolts(adapters, maxJoltRating, new long[] {1, 2, 3});

            }
            catch (System.Exception e) {

                System.Console.WriteLine(e);

            }

            return result;

        }

        public override long partTwo(List<string> input)
        {

            long result = 0;

            List<long> adapters = new List<long>();

            foreach (string item in input) {

                if (item != "") {

                    adapters.Add(long.Parse(item));

                }

            }

            adapters.Sort();

            //result = buildPaths(adapters, new long[] {1, 2, 3}, "", new List<string>(), 0).Count;
            
            return result;

        }

    }

}