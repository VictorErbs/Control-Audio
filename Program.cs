using System;
using System.Windows.Forms;

namespace AudioControlApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of your Form1 class and run the application
            Application.Run(new Form1());
        }
    }
}