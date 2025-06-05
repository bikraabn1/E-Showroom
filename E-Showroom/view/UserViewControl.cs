using System;
using System.Data;
using System.Windows.Forms;
using E_Showroom.model;

namespace E_Transport.view
{
    public partial class UserControl1 : UserControl
    {
        private UserModel _model;
        public UserControl1()
        {
            InitializeComponent();
            _model = new UserModel();
            loadDataGridData();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        void loadDataGridData()
        {
            DataTable dt = _model.getUserDatas();
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _model.Name = textBox1.Text;
            _model.UserName = textBox2.Text;
            _model.Password = textBox3.Text;

            int result = _model.insertUserData();
            if (result >= 0)
            {
                MessageBox.Show(
                    "Data Berhasil Ditambahkan",
                    "Tambah Data User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                Clear();
                loadDataGridData();
                return;
            }
            MessageBox.Show(
            "Data Tidak Valid",
            "Tambah Data Penduduk",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
        }

        void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
