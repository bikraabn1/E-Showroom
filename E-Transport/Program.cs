using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Transport.view;

namespace E_Transport
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
            Form form = new Form();

            // Buat UsersControl
            Dashboard usersControl = new Dashboard();

            // Tambahkan UsersControl ke form
            form.Controls.Add(usersControl);

            // Biar UserControl penuh di form
            usersControl.Dock = DockStyle.Fill;

            // Jalankan form
            Application.Run(form);
        }
    }
}
