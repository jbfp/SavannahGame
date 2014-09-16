using System;
using System.Windows.Forms;

namespace SavannahGame.Forms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm(new Game()));
        }
    }
}