using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_Real.GL
{
    class VerticalGhost : Ghost
    {
        public VerticalGhost(Image character, GameCell startCell, GameDirection direction) : base(character)
        {
            CurrentCell = startCell;
            this.direction = direction;
        }

        public override GameCell move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = CurrentCell.nextCell(direction);

            if (nextCell.CurrentGameObject.type == GameObjectType.PLAYER)
            {
                Game.setFlag();
            }

            this.CurrentCell = nextCell;
            if (nextCell == currentCell)
            {
                if (direction == GameDirection.Up)
                {
                    direction = GameDirection.Down;
                }

                else if (direction == GameDirection.Down)
                {
                    direction = GameDirection.Up;
                }
            }

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());

            }
            return nextCell;
        }
    }
}
