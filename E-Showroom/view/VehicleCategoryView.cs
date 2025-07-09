using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Showroom.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace E_Showroom.view
{
    public partial class VehicleCategoryView : UserControl
    {
        private VehicleCategoryModel _model;
        public VehicleCategoryView()
        {
            InitializeComponent();
            _model = new VehicleCategoryModel();
            loadDataGridData();
        }

        void loadDataGridData()
        {
            DataTable dt = _model.getCategoryDatas();

            dataGridView1.DataSource = dt;

            dataGridView1.RowPostPaint += (sender, e) => {
                dataGridView1.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
            };
        }

        void Clear()
        {
            textBox1.Clear();
            _model.CategoryID = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _model.CategoryName = textBox1.Text;

            int result = _model.insertCategoryData();
            if (result >= 0)
            {
                MessageBox.Show(
                    "Data Berhasil Ditambahkan",
                    "Tambah Data Kategori",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                Clear();
                loadDataGridData();
                return;
            }
            MessageBox.Show(
            "Data Tidak Valid",
            "Tambah Data Kategori",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _model.CategoryName = textBox1.Text;
            _model.updateCategoryData();
            Clear();
            loadDataGridData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _model.deleteCategoryData();
            Clear();
            loadDataGridData();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[2].Value.ToString();
                _model.CategoryID = int.Parse(row.Cells[1].Value.ToString());
            }
        }
    }
}
