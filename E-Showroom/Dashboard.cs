using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Showroom.model;

namespace E_Showroom
{
    public partial class Dashboard : Form
    {
    private UserModel _userModel;
        public Dashboard()
        {
            InitializeComponent();
            _userModel = new UserModel();
            LoadUserCount();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        void LoadUserCount()
        {
            try
            {
                string userCount = _userModel.getTotalUser();
                lblUserCount.Text = userCount ?? "0"; // Jika null, tampilkan "0"
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user count: {ex.Message}");
                lblUserCount.Text = "0";
            }
        }

        private void lblUserCount_Click(object sender, EventArgs e)
        {

        }
    }
}
