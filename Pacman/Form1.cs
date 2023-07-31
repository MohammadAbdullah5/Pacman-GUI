using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman_Real.GL;
using EZInput;

namespace Pacman_Real
{
    public partial class Form1 : Form
    {
        GameGrid grid = new GameGrid("maze.txt", 24, 70);
        GamePacManPlayer pacman;
        HorizontalGhost hGhost;
        VerticalGhost vGhost;
        RandomGhost rGhost;
        SmartGhost sGhost;
        List<Ghost> ghosts = new List<Ghost>();
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image pacmanImage = Game.getImage('P');
            GameCell cell = grid.getCell(13, 43);
            pacman = new GamePacManPlayer(pacmanImage, cell);

            GameCell hGhostCell = grid.getCell(7, 7);
            Image hGhostImg = Game.getImage('h');
            hGhost = new HorizontalGhost(hGhostImg, hGhostCell, GameDirection.Right);

            GameCell vGhostCell = grid.getCell(9, 67);
            Image vGhostImg = Game.getImage('v');
            vGhost = new VerticalGhost(vGhostImg, vGhostCell, GameDirection.Up);

            GameCell rGhostCell = grid.getCell(19, 27);
            Image rGhostImg = Game.getImage('r');
            rGhost = new RandomGhost(rGhostImg, rGhostCell);

            GameCell sGhostCell = grid.getCell(12, 52);
            Image sGhostImg = Game.getImage('s');
            sGhost = new SmartGhost(sGhostImg, sGhostCell, pacman);

            ghosts.Add(hGhost);
            ghosts.Add(vGhost);
            ghosts.Add(rGhost);
            ghosts.Add(sGhost);

            Controls.Add(pacman.CurrentCell.PictureBox);
            Controls.Add(hGhost.CurrentCell.PictureBox);
            Controls.Add(vGhost.CurrentCell.PictureBox);
            Controls.Add(rGhost.CurrentCell.PictureBox);
            Controls.Add(sGhost.CurrentCell.PictureBox);

            printMaze(grid);
        }

        private void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    cell.PictureBox.Visible = true;
                    Controls.Add(cell.PictureBox);
                }
            }
        }

        private void TimeGameLoop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pacman.move(GameDirection.Up);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                pacman.move(GameDirection.Down);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pacman.move(GameDirection.Right);
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pacman.move(GameDirection.Left);
            }

            moveGhosts();

            score = Game.returnScore();
            numScore.Text = score.ToString();

            if(Game.getFlag() == false)
            {
                pacman = new GamePacManPlayer(Game.getImage('p'), grid.getCell(13, 43));
            }
        }

        private void moveGhosts()
        {
            foreach (var ghost in ghosts)
            {
                ghost.move();
            }
        }
    }
}
