using System.Collections.Generic;

namespace adventOfCode2020 {

    public class lineReader {

        public List<string> gatherLines(string lines) {

            List<string> result = new List<string>(lines.TrimEnd('\r').Split("\n"));

            return result;


        }

    }

}