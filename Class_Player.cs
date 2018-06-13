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
			while (!int.TryParse(Console.ReadLine(), out x))
            {
				while (x >= 6 | x <= 1)
				{ Console.WriteLine("Please enter an valid integer."); }
            }

            Console.WriteLine("Please enter the y coordinate that you would like to select");
            while (!int.TryParse(Console.ReadLine(), out y))
            {
				while (y >= 6 | y <= 1)
				{ Console.WriteLine("Please enter an valid integer."); }
            }
            
            coordinates[0] = x;
            coordinates[1] = y;

            return coordinates;

        }

    }

}