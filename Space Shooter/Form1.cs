using EZInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Shooter
{
    public partial class Form1 : Form
    {
        List<PictureBox> playerFires = new List<PictureBox>();
        List<PictureBox> enemyFires = new List<PictureBox>();
        List<PictureBox> meteors = new List<PictureBox>();
        PictureBox enemyRed;
        PictureBox enemyBlue;
        Random rand = new Random();
        string enemyRedDirection = "Left";
        string enemyBlueDirection = "Right";
        int enemyRedLastTimeToFire = 0;
        int enemyBlueLastTimeToFire = 0;
        int enemyRedTimeToFire = 15;
        int enemyBlueTimeToFire = 15;
        int lastMeteorGenerationTime = 0;
        int MeteorGenerationTime = 20;
        int score = 0;
        bool isRedLive = true;
        bool isBlueLive = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void TimeGameLoop_Tick(object sender, EventArgs e)
        {
            lastMeteorGenerationTime++;
            enemyBlueLastTimeToFire++;
            enemyRedLastTimeToFire++;
            removeBullet();
            moveBullet();
            moveEnemyBullet();
            moveEnemy(enemyRed, ref enemyRedDirection);
            moveEnemy(enemyBlue, ref enemyBlueDirection);
            collisionDetection();
            checkVictory();
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pbPlayer.Left += 25;
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pbPlayer.Left -= 25;
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                Image fireImage = Space_Shooter.Properties.Resources.laserBlue01;
                PictureBox pbFire = createFire(fireImage, pbPlayer);
                playerFires.Add(pbFire);
                this.Controls.Add(pbFire);
            }

            if(enemyBlueTimeToFire >= enemyBlueLastTimeToFire)
            {
                Image fireImage = Space_Shooter.Properties.Resources.laserRed01;
                PictureBox pbFire = createFire(fireImage, enemyBlue);
                enemyFires.Add(pbFire);
                this.Controls.Add(pbFire);
                enemyBlueLastTimeToFire = 0;
            }

            if(enemyRedLastTimeToFire >= enemyRedTimeToFire)
            {
                Image fireImage = Space_Shooter.Properties.Resources.laserRed01;
                PictureBox pbFire = createFire(fireImage, enemyRed);
                enemyFires.Add(pbFire);
                this.Controls.Add(pbFire);
                enemyRedLastTimeToFire = 0;
            }
        }

        private void moveBullet()
        {
            foreach (var bullet in playerFires)
            {
                bullet.Top -= 20;
            }
        }

        private void moveEnemyBullet()
        {
            foreach (var bullet in enemyFires)
            {
                bullet.Top += 20;
            }
        }

        private void removeBullet()
        {
            for (int idx = 0; idx < playerFires.Count; idx++)
            {
                if (playerFires[idx].Bottom < 0)
                {
                    playerFires.Remove(playerFires[idx]);
                }
            }
        }        

        private PictureBox createEnemy(Image img)
        {
            PictureBox pbEnemy = new PictureBox();

            int left = rand.Next(30, this.Width);
            int top = rand.Next(5, img.Height + 20);

            pbEnemy.Left = left;
            pbEnemy.Top = top;
            pbEnemy.Height = img.Height;
            pbEnemy.Width = img.Width;
            pbEnemy.BackColor = Color.Transparent;
            pbEnemy.Image = img;
            return pbEnemy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enemyRed = createEnemy(Space_Shooter.Properties.Resources.ufoRed);
            enemyBlue = createEnemy(Space_Shooter.Properties.Resources.ufoBlue);
            this.Controls.Add(enemyBlue);
            this.Controls.Add(enemyRed);
        }

        private void moveEnemy(PictureBox enemy, ref string direction)
        {
            if(direction == "Left")
            {
                enemy.Left -= 10;
            }

            if (direction == "Right")
            {
                enemy.Left += 10;
            }

            if((enemy.Left + enemy.Width) > this.Width)
            {
                direction = "Left";
            }

            if(enemy.Left < 2)
            {
                direction = "Right";
            }
        }

        private PictureBox createFire(Image fireImage, PictureBox source)
        {
            PictureBox pbFire = new PictureBox();
            pbFire.Image = fireImage;
            pbFire.Height = fireImage.Height;
            pbFire.Width = fireImage.Width;
            pbFire.BackColor = Color.Transparent;
            System.Drawing.Point fireLocation;
            fireLocation = new System.Drawing.Point();
            fireLocation.X = source.Left + (source.Width) - 5;
            fireLocation.Y = source.Top;
            pbFire.Location = fireLocation;
            return pbFire;
        }

        private void collisionDetection()
        {
            for (int i = 0; i < enemyFires.Count; i++)
            {
                if(enemyFires[i].Bounds.IntersectsWith(pbPlayer.Bounds))
                {
                    if (pbPlayerHealth.Value > 0)
                    {
                        pbPlayerHealth.Value -= 10;
                    }
                    removeEnemyBullet(enemyFires[i]);
                }
            }

            for (int i = 0; i < playerFires.Count; i++)
            {
                if (playerFires[i].Bounds.IntersectsWith(enemyBlue.Bounds))
                {
                    enemyBlue.Hide();
                    removeBullet(playerFires[i]);
                    isBlueLive = false;
                }

                else if (playerFires[i].Bounds.IntersectsWith(enemyRed.Bounds))
                {
                    removeBullet(playerFires[i]);
                    enemyRed.Hide();
                    isRedLive = false;
                }
            }
        }

        private void removeEnemyBullet(PictureBox bullet)
        {
            enemyFires.Remove(bullet);
            this.Controls.Remove(bullet);
        }

        private void removeBullet(PictureBox bullet)
        {
            playerFires.Remove(bullet);
            this.Controls.Remove(bullet);
        }

        private void checkVictory()
        {
            if(isBlueLive == false && isRedLive == false)
            {
                TimeGameLoop.Enabled = false;
                MessageBox.Show("You Won");
                this.Close();
            }
        }

        private void meteorGenerate()
        {
            if(MeteorGenerationTime >= lastMeteorGenerationTime)
            {
                Image img = Space_Shooter.Properties.Resources.meteorBrown_big1;
                PictureBox pbMeteor = createMeteor(img);
                meteors.Add(pbMeteor);
                this.Controls.Add(pbMeteor);
                lastMeteorGenerationTime = 0;
            }
        }

        private PictureBox createMeteor(Image img)
        {
            PictureBox pbEnemy = new PictureBox();

            int left = rand.Next(30, this.Width);
            int top = rand.Next(5, img.Height + 20);

            pbEnemy.Left = left;
            pbEnemy.Top = top;
            pbEnemy.Height = img.Height;
            pbEnemy.Width = img.Width;
            pbEnemy.BackColor = Color.Transparent;
            pbEnemy.Image = img;
            return pbEnemy;
        }

        private void moveMeteoroid()
        {
            foreach (var meteor in meteors)
            {
                meteor.Top += 10;
            }
        }

        private void scoreFunction()
        {
            foreach(PictureBox bullet in playerFires)
            {
                bool removeBullet = false;

                for (int i = 0; i < meteors.Count; i++)
                {
                    if (meteors[i].Bounds.IntersectsWith(bullet.Bounds))
                    {
                        score += 5;
                        lblScore.Text = "Score: " + score.ToString();
                        meteors[i].Top = this.Height + 2000;
                        meteors[i].Hide();
                        removeBullet = true;
                    }
                }

                if (bullet.Bounds.IntersectsWith(enemyBlue.Bounds))
                {
                    isBlueLive = false;
                    enemyBlue.Hide();
                    removeBullet = true;
                }
            }
        }

        private void showGameEnd(Image img)
        {
            TimeGameLoop.Enabled = false;
            frmGameEnd gameOVer = new frmGameEnd();
            DialogResult dialogResult = gameOVer.ShowDialog();
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }

            if(dialogResult == DialogResult.No)
            {
                restart();
            }
        }
        
        private void createPlayer()
        {
            pbPlayer = new PictureBox();
            Image img = Space_Shooter.Properties.Resources.playerShip1_blue;
            pbPlayer.Height = img.Height;
            pbPlayer.Width = img.Width;
            pbPlayer.Top = this.Height - (img.Height + 60);
            pbPlayer.Image = img;
            pbPlayer.BackColor = Color.Transparent;

            pbPlayerHealth = new ProgressBar();
            pbPlayerHealth.Value = 100;
            pbPlayerHealth.Step = 10;
            pbPlayerHealth.Height = 10;
            pbPlayerHealth.Left = pbPlayer.Left;
            pbPlayerHealth.Top = pbPlayer.Bottom + 2;

            this.Controls.Add(pbPlayer);
            this.Controls.Add(pbPlayerHealth);
        }

        private void restart()
        {
            this.Controls.Clear();
            createPlayer();
            List<PictureBox> playerFires = new List<PictureBox>();
            List<PictureBox> enemyFires = new List<PictureBox>();
            List<PictureBox> meteors = new List<PictureBox>();
            PictureBox enemyRed;
            PictureBox enemyBlue;
            enemyRedDirection = "Left";
            enemyBlueDirection = "Right";
            enemyRedLastTimeToFire = 0;
            enemyBlueLastTimeToFire = 0;
            enemyRedTimeToFire = 15;
            enemyBlueTimeToFire = 15;
            lastMeteorGenerationTime = 0;
            MeteorGenerationTime = 20;
            score = 0;
            isRedLive = true;
            isBlueLive = true;

            Image ib = Space_Shooter.Properties.Resources.ufoBlue;
            enemyBlue = createEnemy(ib);
            Image ir = Space_Shooter.Properties.Resources.ufoRed;
            enemyRed = createEnemy(ir);

            this.Controls.Add(enemyRed);
            this.Controls.Add(enemyBlue);

            TimeGameLoop.Enabled = true;
            this.Controls.Add(lblScore);
        }
    }
}