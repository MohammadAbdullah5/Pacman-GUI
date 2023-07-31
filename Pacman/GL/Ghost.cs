using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pacman_Real.GL
{
    public abstract class Ghost : GameObject
    {
        public Ghost(Image display) : base(GameObjectType.ENEMY, display)
        {

        }

        public GameDirection direction;
        public abstract GameCell move(); 
    }
}
