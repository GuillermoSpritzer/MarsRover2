using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Cambium.MarsRover.Domain
{
    public class Rover
    {
        public int X;
        public int Y;
        public Direction Direction;

        public Rover(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public Direction Rotate(string direction)
        {
            var rotator = 1;
            if (direction == "L")
                rotator = -1;
            Direction += rotator;
            if ((int)Direction > 3)
            {
                Direction = Direction.North;
            }
            if ((int)Direction < 0)
            {
                Direction = Direction.West;
            }
            return Direction;
        }

        public void Move()
        {
            if (Direction == Direction.North)
                Y += 1;
            if (Direction == Direction.East)
                X += 1;
            if (Direction == Direction.South)
                Y -= 1;
            if (Direction == Direction.West)
                X -= 1;
        }

        public override string ToString()
        {
            return string.Format("( {0} {1} {2} )", X, Y, Direction.ToString());
        }
    }
}
