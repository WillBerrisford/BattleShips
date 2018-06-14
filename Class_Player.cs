using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Player
{

    class Player
    {

        private bool win { get; set; }
        private bool player_turn { get; set; }
        public Player()
        { }

		public List<int> choose_coords()
		{
			List<int> coordinates = new List<int>();
			int x = new int();
			int y = new int();

			Console.WriteLine("Please enter the x coordinate that you would like to select");
			while (!int.TryParse(Console.ReadLine(), out x) | (x >= 6 | x <= 1))
			{
				{ Console.WriteLine("Please enter an valid integer between 1 and 6."); }
			}

			Console.WriteLine("Please enter the y coordinate that you would like to select between 1 and 6.");
			while (!int.TryParse(Console.ReadLine(), out y) | (y >= 1 | y <= 6))
			{
				{ Console.WriteLine("Please enter an valid integer."); }
			}

			coordinates[0] = x;
			coordinates[1] = y;

			return coordinates;
		}
        
        public int choose_rotation()
		{
            int rotation_set = new int();
			Console.WriteLine("Which rotation do you wish to use: \n1: Up \n2: Right \n3: Down \n4; Left");
			while (!int.TryParse(Console.ReadLine(), out rotation_set) | (rotation_set >= 1 | rotation_set <= 4))
            {
                { Console.WriteLine("Please enter an valid integer between 1 and 4."); }
            }

			return rotation_set;
        }
        
    }

}