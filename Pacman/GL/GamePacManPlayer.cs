using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_Real.GL
{
    class GamePacManPlayer : GameObject
    {
        public GamePacManPlayer(Image img, GameCell startCell) : base(GameObjectType.PLAYER, img)
        {
            CurrentCell = startCell;
        }

        public GameCell move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            if(nextCell.CurrentGameObject.type == GameObjectType.REWARD)
            {
                Game.addScore();
            }
            this.CurrentCell = nextCell;


            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());

            }
            return nextCell;
        }
    }
}
