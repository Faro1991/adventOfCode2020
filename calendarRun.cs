namespace adventOfCode2020
{

    class calendarRun
    {


        static void Main() {

            day1 firstDay = new day1();
            firstDay.dayRun(1, @"Day1\inputDay1.txt");

            day2 secondDay = new day2();
            secondDay.dayRun(2, @"Day2\inputDay2.txt");

            day3 thirdDay = new day3();
            thirdDay.dayRun(3, @"Day3\inputDay3.txt");

            day4 fourthDay = new day4();
            fourthDay.dayRun(4, @"Day4\inputDay4.txt");

            day5 fifthDay = new day5();
            fifthDay.dayRun(5, @"Day5\inputDay5.txt");

            day6 sixthDay = new day6();
            sixthDay.dayRun(6, @"Day6\inputDay6.txt");

        }


    }


}