using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman_Real.GL
{
    public class GameGrid
    {
        public int Rows;
        public int Cols;
        public GameObject currentGameObject;
        public GameCell[,] gameCells;

        public GameGrid(string filename, int rows, int cols)
        {
            gameCells = new GameCell[rows, cols];
            this.Rows = rows;
            this.Cols = cols;
            loadGrid(filename);

        }

        private void loadGrid(string filename)
        {
            StreamReader file = new StreamReader(filename);
            string record;
            for(int row = 0; row < this.Rows; row++)
            {
                record = file.ReadLine();
                for (int cols = 0; cols < this.Cols; cols++)
                {
                    GameCell cell = new GameCell(row, cols, this);
                    GameObjectType type = GameObject.getGameObjectType(record[cols]);
                    Image image = Game.getImage(record[cols]);
                    GameObject gameObject = new GameObject(type, image);
                    cell.setGameObject(gameObject);
                    gameCells[row, cols] = cell;
                }
            }
            file.Close();
        }

        public GameCell getCell(int x, int y)
        {
            if (gameCells[x, y] != null)
            {
                return gameCells[x, y];
            }

            else
            {
                return null;
            }
        }
    }
}
