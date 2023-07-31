using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_Real.GL
{
    class RandomGhost : Ghost
    {
        public RandomGhost(Image character, GameCell startCell) : base(character)
        {
            this.CurrentCell = startCell;
        }

        public override GameCell move()
        {
            direction = getDirection();
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = CurrentCell.nextCell(direction);
            this.CurrentCell = nextCell;

            if (nextCell.CurrentGameObject.type == GameObjectType.PLAYER)
            {
                Game.setFlag();
            }

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());

            }
            return nextCell;
        }

        public int getRandom()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }

        public GameDirection getDirection()
        {
            int value = getRandom();   
            if(value == 0)
            {
                return GameDirection.Left;
            }

            else if (value == 1)
            {
                return GameDirection.Right;
            }

            else if (value == 2)
            {
                return GameDirection.Up;
            }

            else
            {
                return GameDirection.Down;
            }
        }
    }
}
