using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pacman_Real.GL
{
    public class GameCell
    {
        public int X;
        public int Y;
        public GameGrid grid;
        public GameObject CurrentGameObject;
        PictureBox pictureBox;
        const int width = 24;
        const int height = 19;

        public PictureBox PictureBox { get => pictureBox; set => pictureBox = value; }

        public GameCell(int x, int y, GameGrid grid)
        {
            this.Y = y;
            this.X = x;
            this.grid = grid;
            pictureBox = new PictureBox();
            pictureBox.Size = new Size(width, height);
            pictureBox.Top = x * width;
            pictureBox.Left = y * height;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Visible = true;
        }

        public GameCell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public GameCell nextCell(GameDirection direction)
        {
            if (direction == GameDirection.Up)
            {
                if (this.X > 0)
                {
                    GameCell ncell = grid.getCell(X - 1, Y);
                    if (ncell.CurrentGameObject.type != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }

            if (direction == GameDirection.Down)
            {
                if (this.X < grid.Rows - 1)
                {
                    GameCell ncell = grid.getCell(X + 1, Y);
                    if (ncell.CurrentGameObject.type != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }

            if (direction == GameDirection.Left)
            {
                if (this.Y > 0)
                {
                    GameCell ncell = grid.getCell(X, Y - 1);
                    if (ncell.CurrentGameObject.type != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }
            if (direction == GameDirection.Right)
            {
                GameCell ncell = grid.getCell(X, Y + 1);
                if (this.Y < grid.Cols - 1)
                {
                    if (ncell.CurrentGameObject.type != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }
            return this; // if can not return next cell return its own reference

        }

        public PictureBox getPbCell()
        {
            return pictureBox;
        }

        public PictureBox returnPbCell()
        {
            return pictureBox;
        }

        public Image getImage()
        {
            return CurrentGameObject.DisplayImage;
        }

        public void setGameObject(GameObject gameObject)
        {
            CurrentGameObject = gameObject;
            pictureBox.Image = gameObject.DisplayImage;
        }
    }


    public enum GameDirection
    {
        Left,

        Right,

        Up,

        Down
    }
}
