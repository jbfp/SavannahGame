using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace SavannahGame.Forms
{
    public partial class GameForm : Form
    {
        private readonly Game game;
        private readonly Timer timer;
        private readonly Bitmap sand;
        private readonly Bitmap grass;
        private readonly Bitmap lion;
        private readonly Bitmap rabbit;

        public GameForm(Game game)
        {
            this.game = game;
            this.timer = new Timer(Tick, null, TimeSpan.FromMilliseconds(0), TimeSpan.FromSeconds(2));
            this.sand = new Bitmap("Content/sand.png");
            this.grass = new Bitmap("Content/grass.png");
            this.lion = new Bitmap("Content/lion.png");
            this.rabbit = new Bitmap("Content/rabbit.png");
            InitializeComponent();
        }

        private void Tick(object state)
        {
            game.Tick();
            savannahPictureBox.Invalidate();
        }

        private void savannahPictureBox_Paint(object sender, PaintEventArgs e)
        {
            const int size = 32;
            const int padding = 1;

            for (int row = 0; row < game.Savannah.Rows; row++)
            {
                for (int column = 0; column < game.Savannah.Columns; column++)
                {
                    var grass = this.game.Savannah.Grasses[row, column];
                    var rectangle = new Rectangle((size + padding) * column, (size + padding) * row, size, size);

                    e.Graphics.DrawImage(this.sand, rectangle);
                    
                    if (grass.IsAlive)
                    {
                        e.Graphics.DrawImage(this.grass, rectangle);
                    }

                    var animal = this.game.Savannah.Animals[row, column];

                    if (animal == null)
                    {
                        continue;
                    }

                    if (animal is Lion)
                    {
                        e.Graphics.DrawImage(this.lion, rectangle);
                    }
                    else if (animal is Rabbit)
                    {
                        e.Graphics.DrawImage(this.rabbit, rectangle);
                    }
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.sand.Dispose();
            this.grass.Dispose();
            this.lion.Dispose();
            this.rabbit.Dispose();
            base.OnClosing(e);
        }
    }
}