using System;
using System.Linq;
using System.Collections.Generic;

namespace adventOfCode2020 {

    class day5 : dayBase {

        private long identifyRow(string instructions, int[] rows) {

            long result = 0;

            if (instructions.Length > 0) {

                int offset = 0;
                int count = 0;


                if (instructions.StartsWith('F')) {

                    offset = (rows.GetUpperBound(0) / 2) + 1;
                    count = (rows.Length / 2);
                
                }
                else {

                    offset = 0;
                    count = (rows.Length / 2);

                }

                List<int> newRows = new List<int>(rows);
                newRows.RemoveRange(offset, count);

                string newInstructions = instructions.Remove(0,1);

                result = identifyRow(newInstructions, newRows.ToArray());

            }
            else {
            
                result = rows[0];

            }

            return result;

        }

        private long identifyColumn(string instructions, int[] colums) {

            long result = 0;

            if (instructions.Length > 0) {

                int offset = 0;
                int count = 0;


                if (instructions.StartsWith('L')) {

                    offset = (colums.GetUpperBound(0) / 2) + 1;
                    count = (colums.Length / 2);
                
                }
                else {

                    offset = 0;
                    count = (colums.Length / 2);

                }

                List<int> newColumns = new List<int>(colums);
                newColumns.RemoveRange(offset, count);

                string newInstructions = instructions.Remove(0,1);

                result = identifyColumn(newInstructions, newColumns.ToArray());

            }
            else {
            
                result = colums[0];

            }

            return result;

        }

        private List<long> listBoardingPasses(List<string> input) {

            int[] rows = Enumerable.Range(0, 128).ToArray();
            int[] columns = Enumerable.Range(0, 8).ToArray();
            long row = 0;
            long column = 0;
            List<long> seatIds = new List<long>();
            long seatId = 0;
            string rowInstruction = "";
            string colInstruction = "";

            foreach (string instruction in input) {
                
                if (instruction != "") {
                    rowInstruction = instruction.Remove(instruction.Length - 3, 3);
                    colInstruction = instruction.Remove(0, 7);

                    row = identifyRow(rowInstruction, rows);
                    column = identifyColumn(colInstruction, columns);

                    seatId = (row * 8) + column;

                    seatIds.Add(seatId);
                }

            }

            seatIds.Sort();

            return seatIds;

        }
        public override long partOne(List<string> input)
        {
            
            long result = listBoardingPasses(input).Max();
            return result;

        }

        public override long partTwo(List<string> input)
        {

            List<long> boardingPasses = listBoardingPasses(input);
            List<long> missingPasses = new List<long>();
            long result = 0;

            long counter = boardingPasses.First();

            foreach (long pass in boardingPasses) {

                if (pass != counter) {

                    missingPasses.Add(counter);
                    ++counter;

                }
                ++counter;

            }

            if (missingPasses.Count != 0) {

                result = missingPasses.First();

            }

            return result;
        }

    }

}