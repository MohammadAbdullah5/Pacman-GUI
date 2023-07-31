using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pacman_Real.GL
{
    public class Game
    {
        static int score = 0;
        static bool flag = true;

        public static void addScore()
        {
            score++;
        }

        public static void setFlag()
        {
            flag = false;
        }

        public static bool getFlag()
        {
            return flag;
        }

        public static int returnScore()
        {
            return score;
        }

        public static GameObject getBlankGameObject()
        {
            GameObject blank = new GameObject(GameObjectType.NONE, Properties.Resources.simplebox);
            return blank;
        }

        public static Image getImage(char character)
        {
            Image img = Pacman_Real.Properties.Resources.simplebox;
            if (character == '|' || character == '%')
            {
                img = Pacman_Real.Properties.Resources.vertical;
            }

            else if (character == '#')
            {
                img = Pacman_Real.Properties.Resources.horizontal;
            }

            else if (character == '.')
            {
                img = Pacman_Real.Properties.Resources.score;
            }
            else if (character == 'P' || character == 'p')
            {
                img = Pacman_Real.Properties.Resources.pacman;
            }

            else if (character == 'h' || character == 'H')
            {
                img = Pacman_Real.Properties.Resources.ghost_blue;
            }

            else if (character == 'v' || character == 'v')
            {
                img = Pacman_Real.Properties.Resources.ghost_orange;
            }

            if (character == 'r' || character == 'r')
            {
                img = Pacman_Real.Properties.Resources.ghost_pink;
            }

            if (character == 's' || character == 'S')
            {
                img = Pacman_Real.Properties.Resources.ghost_red;
            }

            return img;
        }
    }
}
