using System;
using System.Windows.Forms;
using E_Showroom;

namespace E_Showroom
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login loginForm = new Login();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Dashboard());
            }
        }
    }
}
