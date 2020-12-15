namespace adventOfCode2020 {

    class seat {

        private string[][] neighbours = new string[3][];
        private string state = "";

        private void checkNeighbours(long xPos, long yPos) {

            

        }

        public void calcState(long xPos, long yPos) {

            long countOccupied = 0;

            foreach (string[] seats in neighbours) {

                foreach (string state in seats) {

                    if (state == "#") {

                        ++countOccupied;

                    }

                }

            }



        }

    }

}