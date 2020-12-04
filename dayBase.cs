using System;
using System.Collections.Generic;
using System.Net;

namespace adventOfCode2020
{
    
    public abstract class dayBase {

        public abstract long partOne(List<string> input);
        public abstract long partTwo(List<string> input);

        public virtual void getInput(int day) {

            string filePath = "day" + day + @"\inputDay" + day + ".txt";

            string domain = @".adventofcode.com";
            string url = @"https://adventofcode.com/2020/day/" + day + @"/input";
            string autcVal = System.IO.File.ReadAllText(@"cookie.autc");

            HttpWebRequest download = (HttpWebRequest) WebRequest.Create(url);
            Cookie authCookie = new Cookie("session", autcVal);
            authCookie.Domain = domain;
            download.CookieContainer = new CookieContainer(1);
            download.CookieContainer.Add(authCookie);

            WebResponse inputText = download.GetResponse();

            string result = new System.IO.StreamReader(inputText.GetResponseStream()).ReadToEnd();

            System.IO.File.WriteAllText(filePath, result);


        }

        public virtual void dayRun(int day, string input) {

            if (!System.IO.Directory.Exists("day" + day)) {

                System.IO.Directory.CreateDirectory("day" + day);

            }

            if (!System.IO.File.Exists(input)) {

                getInput(day);

            }
            

            lineReader read = new lineReader();
            resultWriter write = new resultWriter();
            performanceTime timer = new performanceTime();

            string text = System.IO.File.ReadAllText(input);
            List<string> items = read.gatherLines(text);

            TimeSpan timer1 = timer.measuredTime(() => partOne(items));
            TimeSpan timer2 = timer.measuredTime(() => partTwo(items));

            long result = partOne(items);
            long resultPartTwo = partTwo(items);

            write.timesTaken.Add(timer1);
            write.timesTaken.Add(timer2);
            write.partResults.Add("part one", result.ToString());
            write.partResults.Add("Part two", resultPartTwo.ToString());

            write.writeResults(day);

        }

    }

}