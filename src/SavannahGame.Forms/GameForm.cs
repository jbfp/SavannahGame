using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SavannahGame.Forms
{
    public partial class GameForm : Form
    {
        private const int Rows = 20;
        private const int Columns = 20;

        private readonly Game game;
        private readonly Dictionary<string, Image> textures;
        private readonly CancellationTokenSource cts;
        private readonly AutoResetEvent are;
        private readonly Thread loop;
        
        private int delay;

        public GameForm()
        {
            this.game = new Game(new Savannah(Rows, Columns));
            this.textures = new Dictionary<string, Image>();
            this.loop = new Thread(() => Tick(cts.Token));
            this.are = new AutoResetEvent(false);
            this.cts = new CancellationTokenSource();
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.textures["Sand"] = new Bitmap("Content/sand.png");
            this.textures["Grass"] = new Bitmap("Content/grass.png");
            this.textures["Lion"] = new Bitmap("Content/lion.png");
            this.textures["Rabbit"] = new Bitmap("Content/rabbit.png");
            this.textures["Cross"] = new Bitmap("Content/cross.png");            
            this.delay = this.delayTrackBar.Value;            
            base.OnLoad(e);
        }

        private void Tick(CancellationToken token)
        {
            while (true)
            {
                IEnumerable<Action> actions = this.game.Tick();

                foreach (var action in actions)
                {
                    action();
                    this.savannahPictureBox.Invalidate();
                    this.are.WaitOne();
                    Thread.Sleep(this.delay);                                                    

                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                }
            }
        }

        private void savannahPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var min = Math.Min(e.ClipRectangle.Width, e.ClipRectangle.Height);
            var width = min / Columns;
            var height = min / Rows;
            var size = new Size(width, height);
            var visitor = new GraphicsVisitor(e.Graphics, this.textures, size);
            var counter = new CounterVisitor();
            this.game.Accept((ISavannahVisitor) visitor);
            this.game.Accept((IAnimalVisitor) visitor);
            this.game.Accept(counter);
            this.lionsTextBox.Text = counter.Lions.ToString("N0");
            this.rabbitsTextBox.Text = counter.Rabbits.ToString("N0");
            this.are.Set();
        }

        private void delayTrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.delay = this.delayTrackBar.Value;
            this.delayLabel.Text = this.delay.ToString("0,0 ms");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.loop.ThreadState != ThreadState.Running)
            {
                this.loop.Start();
                this.startButton.Enabled = false;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.cts.Cancel();

                if (this.loop.IsAlive)
                {
                    this.loop.Join();
                }

                this.cts.Dispose();
                this.are.Dispose();

                foreach (var image in textures.Values)
                {
                    image.Dispose();
                }

                this.textures.Clear();
            }

            base.Dispose(disposing);
        }
    }
}