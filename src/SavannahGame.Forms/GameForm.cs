using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavannahGame.Forms
{
    public partial class GameForm : Form
    {
        private readonly Game game;
        private readonly Thread loop;

        private Bitmap sand;
        private Bitmap grass;
        private Bitmap grassCut;
        private Bitmap lion;
        private Bitmap rabbit;
        private Bitmap cross;
        private Bitmap circle;
        private Font font;

        private int delay;
        private int steps;

        public GameForm(Game game)
        {
            this.game = game;
            this.loop = new Thread(Tick);

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.sand = new Bitmap("Content/sand.png");
            this.grass = new Bitmap("Content/grass.png");
            this.grassCut = new Bitmap("Content/grass_cut.png");
            this.lion = new Bitmap("Content/lion.png");
            this.rabbit = new Bitmap("Content/rabbit.png");
            this.cross = new Bitmap("Content/cross.png");
            this.circle = new Bitmap("Content/circle.png");
            this.font = new Font("Arial", 8);
            this.stepsTrackBar.Value = this.steps = this.stepsTrackBar.Minimum;
            this.delayTrackBar.Value = this.delay = this.delayTrackBar.Minimum;
            this.loop.Start();
            base.OnLoad(e);
        }

        private async void Tick()
        {
            while (true)
            {
                try
                {
                    var tasks = this.game.TickAsync();

                    foreach (var task in tasks)
                    {
                        await task;
                        savannahPictureBox.Invalidate();
                        await Task.Delay(TimeSpan.FromMilliseconds(this.delay));
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        private void savannahPictureBox_Paint(object sender, PaintEventArgs e)
        {
            const int size = 32;
            const int padding = 0;

            for (int row = 0; row < game.Savannah.Rows; row++)
            {
                for (int column = 0; column < game.Savannah.Columns; column++)
                {
                    var rectangle = new Rectangle((size + padding) * column, (size + padding) * row, size, size);

                    e.Graphics.DrawImage(this.sand, rectangle);

                    if (this.game.Savannah.Grasses[row, column].IsAlive)
                    {
                        e.Graphics.DrawImage(this.grass, rectangle);
                    }

                    var animal = this.game.Savannah.Animals[row, column];

                    if (animal == null)
                    {
                        continue;
                    }

                    Bitmap animalImage = animal is Lion ? this.lion : this.rabbit;              
                    e.Graphics.DrawImage(animalImage, rectangle);

                    if (animal.IsAlive == false)
                    {
                        e.Graphics.DrawImage(this.cross, rectangle);
                    }
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.sand.Dispose();
            this.grass.Dispose();
            this.grassCut.Dispose();
            this.lion.Dispose();
            this.rabbit.Dispose();
            this.cross.Dispose();
            this.circle.Dispose();
            this.font.Dispose();
            base.OnClosing(e);
        }

        private void delayTrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.delay = this.delayTrackBar.Value;
            this.delayLabel.Text = this.delay.ToString("0,0 ms");
        }

        private void stepsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.steps = this.stepsTrackBar.Value;
            this.stepsLabel.Text = this.steps.ToString("N0");
        }
    }
}