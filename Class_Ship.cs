using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Ship
{

    class Ship
    {

        private bool Sunk { get; set; }
        private int[] Coordinates_taken { get; set; }
        private string Ship_type { get; set; }
        private int Rotation { get; set; }
        private int Length { get; set; }

        public Ship(string type)
        {
            Sunk = false;
            Ship_type = type;
        }

        public int Set_rotation(int user_rotation)
        {
            Rotation = user_rotation;
            return Rotation;
        }

        public int[,] Set_coords(int xcoord, int ycoord, int Rotation, int Length, int[,] Coordinates_taken)
        {

            int rotation_offset_x = rotation_offset(Rotation, 2);
            int rotation_offset_y = rotation_offset(Rotation, 1);

            int length_counter = 1;

            while (length_counter > Length)
            {
                int coord_x = xcoord + rotation_offset_x + length_counter;
                int coord_y = ycoord + rotation_offset_y + length_counter;

                Coordinates_taken[length_counter, 1] = coord_x;
                Coordinates_taken[length_counter, 2] = coord_y;
                length_counter++;
            }
            return Coordinates_taken;
        }

        public int rotation_offset(int Rotation, int x_or_y)
        {
            int offset_x = 0;
            int offset_y = 0;

            switch (x_or_y)
            {
                case 1:
                    offset_y = rotation_offset_y(Rotation);
                    return offset_y;

                case 2:
                    offset_x = rotation_offset_x(Rotation);
                    return offset_x;

                case 3:
                    offset_y = rotation_offset_y(Rotation);
                    return offset_y;

                case 4:
                    offset_x = rotation_offset_x(Rotation);
                    return offset_x;
            }
            return 0;
        }

        public int rotation_offset_x(int Rotation)
        {
            int offset_x = 0;

            switch (Rotation)
            {
                case 2:
                    offset_x = offset_x + 1;
                    return offset_x;

                case 4:
                    offset_x = offset_x - 1;
                    return offset_x;
            }
            return offset_x;
        }

        public int rotation_offset_y(int Rotation)
        {
            int offset_y = 0;

            switch (Rotation)
            {
                case 1:
                    offset_y = offset_y + 1;
                    return offset_y;

                case 3:
                    offset_y = offset_y - 1;
                    return offset_y;
            }
            return offset_y;
        }

        public bool Sunk_Ship()
        {
            Sunk = true;
            return Sunk;
        }
    }

}

