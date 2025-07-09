using System;
using System.Windows.Forms;
using E_Showroom.model;

namespace E_Showroom
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserModel _userModel = new UserModel();
            if(_userModel.LoginUser(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Login Berhasil");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username atau Password Salah");
            }
        }
    }
}
