using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace adventOfCode2020 {

    class bag {

        private string name = "";
        private HashSet<string> containedBags = new HashSet<string>();

        private long returnContainedAmount() {

            long result = 0;

            foreach (string contained in containedBags) {

                Match match = Regex.Match(contained, @"\d+");

                result += long.Parse(match.Value);


            }

            return result;

        }

        public void addBags(IEnumerable<string> bags) {

            this.containedBags.UnionWith(bags);

        }

        public void setName(string name) {

            this.name = name;

        }

        public string getName() {

            return this.name;

        }

        public HashSet<string> returnBags() {

            return this.containedBags;

        }

        public void clearData() {

            this.containedBags.Clear();

        }

    }

}