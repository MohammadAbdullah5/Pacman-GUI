using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_Real.GL
{
    class SmartGhost : Ghost
    {
        public GamePacManPlayer pacman;
        public SmartGhost(Image character, GameCell startCell, GamePacManPlayer pacman) : base(character)
        {
            CurrentCell = startCell;
            this.pacman = pacman;
        }

        public override GameCell move()
        {
            direction = getDirection();
            direction = getDirection();
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = CurrentCell.nextCell(direction);

            if(nextCell.CurrentGameObject.type == GameObjectType.PLAYER)
            {
                Game.setFlag();
            }

            this.CurrentCell = nextCell;

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());

            }
            return nextCell;
        }

        public GameDirection getDirection()
        {
            double[] distance = new double[4];
            distance = getDistances();
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                return GameDirection.Up;
            }

            else if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                return GameDirection.Down;
            }

            else if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                return GameDirection.Left;
            }

            else if(distance[3] <= distance[0] && distance[3] <= distance[1] && distance[3] <= distance[2])
            {
                return GameDirection.Right;
            }

            return GameDirection.Down;
        }

        public double[] getDistances()
        {
            double[] list = new double[4];
            list[0] = calculateDistance(CurrentCell.X - 1, CurrentCell.Y, pacman.CurrentCell.X, pacman.CurrentCell.Y); // Up 
            list[1] = calculateDistance(CurrentCell.X + 1, CurrentCell.Y, pacman.CurrentCell.X, pacman.CurrentCell.Y); // Down
            list[2] = calculateDistance(CurrentCell.X, CurrentCell.Y - 1, pacman.CurrentCell.X, pacman.CurrentCell.Y); // Left
            list[3] = calculateDistance(CurrentCell.X, CurrentCell.Y + 1, pacman.CurrentCell.X, pacman.CurrentCell.Y); // Right
            return list;
        }

        static double calculateDistance(int X, int Y, int pX, int pY)
        {
            return Math.Sqrt(Math.Pow((pX - X), 2) + Math.Pow((pY - Y), 2));
        }

    }
}
