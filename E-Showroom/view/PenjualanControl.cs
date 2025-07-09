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

            dataGridView1.RowPostPaint += (sender, e) => {
                dataGridView1.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
            };


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
            
        }

        void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            _model.UserID = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                _model.UserID = int.Parse(row.Cells[1].Value.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            _model.Name = textBox1.Text;
            _model.UserName = textBox2.Text;
            _model.Password = textBox3.Text;
            _model.updateUserData();
            Clear();
            loadDataGridData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            _model.deleteUserData();
            Clear();
            loadDataGridData();
        }
    }
}
