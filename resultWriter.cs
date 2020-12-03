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

                Console.WriteLine("Time taken (part " + (timesTaken.IndexOf(time) + 1) + "): " + time);

            }

            Console.WriteLine("\n\n");

        }

    }

}