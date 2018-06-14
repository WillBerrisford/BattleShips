using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Grid
{

    class Grid
    {

        private int Ships_left { get; set; }
        private List<List<int>> Occupied_coords { get; set; }
        private List<List<int>> Hit_coords { get; set; }
        private List<List<int>> Miss_coords { get; set; }
		private List<List<string>> Full_grid { get; set; }
		private List<List<int>> Ship_coords { get; set; }
        
        public Grid()
        {
			Ships_left = 4;
			for (int i = 0; i <= 6; i++)
			{
				for (int j = 0; j <= 6; j++)
				{
					Full_grid[i][j] = "[ ]";
				}
			}
        }

        //takes in 2d list of coords to be added, returns Occupied_coords with new coordinates added.
        public List<List<int>> Place_ship(List<List<int>> Used_coords)
        {

            Occupied_coords[0].AddRange(Used_coords[0]); //These are the x coordinates
            Occupied_coords[1].AddRange(Used_coords[1]); //These are the y coordinates
			Ship_coords[0].AddRange(Used_coords[0]);
			Ship_coords[1].AddRange(Used_coords[1]);
            return Occupied_coords;

        }

        //takes in a list of coords to be added, returns Hit_coords with new coordinates added.
        public List<List<int>> Add_hit(List<int> Used_coords)
        {

            Hit_coords[0].Add(Used_coords[0]);//These are the x coordinates
            Hit_coords[1].Add(Used_coords[1]);//These are the y coordinates
			if (Ship_coords[0].Contains(Used_coords[0]) && Ship_coords[1].Contains(Used_coords[1]))
			Ship_coords[0].RemoveAll(value => value == Used_coords[0]);
			Ship_coords[1].RemoveAll(value => value == Used_coords[1]);
            return Hit_coords;

        }

        //takes in a list of coords to be added, returns Miss_coords with new coordinates added.
        public List<List<int>> Add_miss(List<int> Used_coords)
        {

            Miss_coords[0].Add(Used_coords[0]);//These are the x coordinates
            Miss_coords[1].Add(Used_coords[1]);//These are the y coordinates
            return Miss_coords;

        }

        //
        public List<List<int>> Generate_coords(int Rotation, List<int> Base_coords, int Length)
        {

            List<List<int>> Generated_coords = new List<List<int>>();

            switch (Rotation)
            {
                case 1:
                    Generated_coords[0] = Unchanging_coord(0, Base_coords, Length);
                    Generated_coords[1] = Changing_coord(1, Base_coords, Length, 1);
                    return Generated_coords;

                case 3:
                    Generated_coords[0] = Unchanging_coord(0, Base_coords, Length);
                    Generated_coords[1] = Changing_coord(1, Base_coords, Length, -1);
                    return Generated_coords;

                case 2:
                    Generated_coords[1] = Unchanging_coord(1, Base_coords, Length);
                    Generated_coords[0] = Changing_coord(0, Base_coords, Length, 1);
                    return Generated_coords;

                case 4:
                    Generated_coords[1] = Unchanging_coord(1, Base_coords, Length);
                    Generated_coords[0] = Changing_coord(0, Base_coords, Length, -1);
                    return Generated_coords;


            }
            return Generated_coords;
        }

        public List<int> Unchanging_coord(int X_or_y, List<int> Base_coords, int Length)
        {
            int Coordinate = Base_coords[X_or_y];
            List<int> Unchanged_coords = new List<int>();

            for (int num = 1; num <= Length; num++)
            {
                Unchanged_coords.Add(Coordinate);
            }

            return Unchanged_coords;
        }

        public List<int> Changing_coord(int X_or_y, List<int> Base_coords, int Length, int Rotation_offset)
        {

            int Coordinate = Base_coords[X_or_y];
            List<int> Changed_coords = new List<int>();

            for (int num = 1; num <= Length; num++)
            {
                Changed_coords.Add(Coordinate);
                Coordinate = Coordinate + Rotation_offset;
            }

            return Changed_coords;
        }

        //takes in a list of possible coordinates for ships and currently occupied coordinates,
        //returns a bool value depending whether they are occupied or not and returns a 2d list of the first coordinates that are taken
        public (bool, List<List<int>>) Check_coords(List<List<int>> Possible_coords) //returns true if coordinates are occupied, false if they are not.
        {
            List<List<int>> taken_coords = new List<List<int>>();
            
            foreach (int x_coord in Possible_coords[0])  //runs through all x coordinates
            {
                if (Occupied_coords[0].Contains(x_coord)) //adds checks if x coordinate is present
                {

                    int index = Occupied_coords[0].IndexOf(x_coord); //finds index of x coorinate
                    if (Occupied_coords[1][index] == Possible_coords[1][index]) //checks whether the y coordinates in the Occupied_coords list and Possible_coords list is the same at the given index
                    {
                        taken_coords[0].Add(x_coord); //adds the taken x coordinate
                        taken_coords[1].Add(Possible_coords[1][index]); //adds the taken y coordinate
                        return (true, taken_coords);
                    }
                    else
                    {

                        return (false, taken_coords);
                    }

                }
                else
                {
                    break;
                }
            }
            return (false, taken_coords);
        }



    }

}