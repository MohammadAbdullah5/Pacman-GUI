using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_Real.GL
{
    class HorizontalGhost : Ghost
    {
        public HorizontalGhost(Image character, GameCell startCell, GameDirection direction) : base(character)
        {
            this.CurrentCell = startCell;
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
                if (direction == GameDirection.Left)
                {
                    direction = GameDirection.Right;
                }

                else if (direction == GameDirection.Right)
                {
                    direction = GameDirection.Left;
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
