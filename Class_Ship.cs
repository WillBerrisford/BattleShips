using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Ship
{

    class Ship
    {
        //initializes all variables
        private bool Sunk { get; set; } //whether ship was sunk or not
		private List<List<int>> Coordinates_taken { get; set; } //which coordinates the ship takes up
        private int Ship_type { get; set; } //what type of ship the ship is out of (1,2,3,4)
        private string Ship_type_string { get; set; } //what type of ship the ship is (Carrier, Battleship, Destroyer, Carrier
        private int Rotation { get; set; } //the rotation offset (1,2,3,4)
        private int Length { get; set; } //length of the ship in grid squares.

        //default construtor, requires type of ship
        public Ship(int typeIN)
        {
            Sunk = false; //ships are not sunk when initialized
			int type = typeIN; //sets the type of ship
			Ship_type = type;

            switch (type) //depending on type of ship a different label will be given
            {
                case 1: //if ship is type 1 (carrier)
                    Length = 4;
                    Ship_type_string = "Carrier";
                    break;

                case 2:
                    Length = 3;
                    Ship_type_string = "Battleship";
                    break;

                case 3:
                    Length = 2;
                    Ship_type_string = "Destroyer";
                    break;

                case 4:
                    Length = 1;
                    Ship_type_string = "Submarine";
                    break;
            }
        }

        //needs expanding
        //sets rotation function for setting rotation, requires user input
        public int Set_rotation(int user_rotation)
        {
            Rotation = user_rotation;
            return Rotation;
        }

        public bool Sunk_Ship()
        {
            Sunk = true;
            return Sunk;
        }
    }

}