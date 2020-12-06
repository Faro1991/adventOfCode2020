using System;
using System.Collections.Generic;

namespace adventOfCode2020 {

    class resultWriter {

        public List<TimeSpan> timesTaken {get; set;} = new List<TimeSpan>();

        public Dictionary<string, string> partResults {get; set;} = new Dictionary<string, string>();
        public void writeResults(int day) {

            Console.WriteLine("---------------------");
            Console.WriteLine("Day " + day + ": ");
            Console.WriteLine("---------------------");
            foreach (KeyValuePair<string, string> item in partResults) {

                Console.WriteLine(item.Key + ": " + item.Value);

            }


            foreach (TimeSpan time in timesTaken) {

                if (time.TotalMilliseconds < 1000) {

                    Console.WriteLine("Time taken (part " + (timesTaken.IndexOf(time) + 1) + "): " + time.TotalMilliseconds + "ms");

                }
                else {

                     Console.WriteLine("Time taken (part " + (timesTaken.IndexOf(time) + 1) + "): " + time.Seconds + "s");

                }

            }

            Console.WriteLine("\n\n");

        }

    }

}