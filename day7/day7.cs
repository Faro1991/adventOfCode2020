using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace adventOfCode2020 {

    class day7 : dayBase {

        private bag addBags(string input, bool countNumber) {

            string regEx = "";

            if (!countNumber) {

                regEx = @"(\w+\s+){1,2}(?=bags?)";

            }
            else {

                regEx = @"(\d+\s+)?(\w+\s+){1,2}(?=bags?)";

            }

            MatchCollection matches = Regex.Matches(input, regEx);

            string matchName = matches[0].Value.ToLower().Trim();
            Match[] matchArray = new Match[matches.Count];
            matches.CopyTo(matchArray, 0);
            List<Match> matchList = matchArray.ToList<Match>();
            matchList.RemoveAt(0);

            List<string> containedBags = new List<string>();
            foreach (Match match in matchList) {

                containedBags.Add(match.Value.ToLower().Trim());

            }

            bag addBag = new bag();

            addBag.setName(matchName);
            addBag.addBags(containedBags);

            return addBag;

        }

        private HashSet<bag> buildFullBagList(List<bag> bagList) {

            List<bag> result = bagList;

            foreach (bag bag in bagList) {

                List<bag> posFind = bagList.FindAll(x => x.returnBags().Contains(bag.getName()));
                foreach (bag hit in posFind) {

                    int posInResult = result.FindIndex(x => x == hit);

                    result.ElementAt(posInResult).addBags(bag.returnBags());

                }

            }

            return new HashSet<bag>(result);

        }

        private long findNumberofContainedBags(string name, List<bag> bagList) {

            long result = 0;

            bag bag = bagList.Find(x => x.getName() == name);

            if (bag != null) {

                List<string> content = bag.returnBags().ToList();

                foreach (string contained in content) {


                    if (contained != "no other") {

                        string newName = Regex.Match(contained, @"(?<=\d+\s+)(\w+\s*){1,2}").Value;
                        Match match = Regex.Match(contained, @"\d+");

                        long amountOfBags = long.Parse(match.Value);

                        result += (findNumberofContainedBags(newName, bagList) * amountOfBags) + amountOfBags;

                    }
                    else {

                        return 0;

                    }

                }

                

                return result;

            }
            else {

                return 0;

            }


        }

        public override long partOne(List<string> input)
        {

            long result = 0;
            HashSet<bag> bagCollection = new HashSet<bag>();

            foreach (string item in input) {

                if (item != "") {
                
                    bagCollection.Add(addBags(item, false));
                
                }

            }

            bagCollection = buildFullBagList(bagCollection.ToList());

            result = bagCollection.ToList().FindAll(x => x.returnBags().Contains("shiny gold")).Count;

            return result;

        }

        public override long partTwo(List<string> input)
        {

            long result = 0;
            
            HashSet<bag> bagCollection = new HashSet<bag>();

            foreach (string item in input) {

                if (item != "") {
                
                    bagCollection.Add(addBags(item, true));
                
                }

            }

            bagCollection = buildFullBagList(bagCollection.ToList());


            result = findNumberofContainedBags("shiny gold", bagCollection.ToList());


            return result;

        }

    }

}