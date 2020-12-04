using System.Collections.Generic;

namespace adventOfCode2020 {

    class passport {

        private Dictionary<string, string> passportData = new Dictionary<string, string>();

        public void addPassportEntry(string key, string value) {


            this.passportData.Add(key, value);


        }

        public Dictionary<string, string> getFields() {

            return this.passportData;

        }

        public void clearData() {

            this.passportData.Clear();

        }

    }

}