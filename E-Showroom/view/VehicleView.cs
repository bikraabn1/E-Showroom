using System;
using System.Data;
using System.Windows.Forms;
using E_Showroom.model;

namespace E_Showroom.view
{
    public partial class VehicleView : UserControl
    {
        private VehicleModel _model;
        public VehicleView()
        {
            InitializeComponent();
            _model = new VehicleModel();
            loadDataGridData();
            loadCategoryList();
        }

        void loadDataGridData()
        {
            DataTable dt = _model.getVehicleDatas();

            dataGridView1.DataSource = dt;

            dataGridView1.RowPostPaint += (sender, e) => {
                dataGridView1.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
            };
        }

        void loadCategoryList()
        {
            try
            {
                comboBox2.Items.Clear();
                DataTable dt = _model.getCategoryList();
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "nama_kategori";
                comboBox2.ValueMember = "id_kategori";
                comboBox2.SelectedValue = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data kategori: " + ex.Message);
            }
        }

        void Clear()
        {
            textBox1.Clear();
            _model.VehicleID = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Semua kolom harus diisi.", "Input Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox3.Text, out int tahun))
                {
                    MessageBox.Show("Tahun harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }

                if (!long.TryParse(textBox6.Text, out long harga))
                {
                    MessageBox.Show("Harga harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox6.Focus();
                    return;
                }

                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Silakan pilih status kendaraan.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox1.Focus();
                    return;
                }

                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Silakan pilih kategori kendaraan.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.Focus();
                    return;
                }

                _model.Merk = textBox1.Text;
                _model.Type = textBox2.Text;
                _model.Year = textBox3.Text; 
                _model.Color = textBox4.Text;
                _model.Plate = textBox5.Text;
                _model.Price = textBox6.Text; 
                _model.Status = comboBox1.SelectedItem.ToString(); 
                _model.CategoryID = Convert.ToInt32(comboBox2.SelectedValue);

                int result = _model.insertVehicleData();
                if (result > 0) 
                {
                    MessageBox.Show(
                        "Data Berhasil Ditambahkan",
                        "Tambah Data Kendaraan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    Clear();
                    loadDataGridData();
                }
                else
                {
                    MessageBox.Show(
                        "Gagal menambahkan data.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi error: " + ex.Message, "Kesalahan Kritis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _model.deleteVehicleData();
            Clear();
            loadDataGridData();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["merk"].Value?.ToString();
                textBox2.Text = row.Cells["tipe"].Value?.ToString();
                textBox3.Text = row.Cells["tahun"].Value?.ToString();
                textBox4.Text = row.Cells["warna"].Value?.ToString();
                textBox5.Text = row.Cells["nomor_polisi"].Value?.ToString();
                textBox6.Text = row.Cells["harga"].Value?.ToString();
                comboBox1.SelectedItem = row.Cells["status"].Value;

                if (row.Cells["id_kategori"].Value != null)
                {
                    comboBox2.SelectedValue = row.Cells["id_kategori"].Value;
                }

                if (row.Cells["id_kendaraan"].Value != null &&
                    int.TryParse(row.Cells["id_kendaraan"].Value.ToString(), out int vehicleID))
                {
                    _model.VehicleID = vehicleID;
                }
                else
                {
                    MessageBox.Show("ID Kendaraan tidak valid.");
                }
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            _model.Merk = textBox1.Text;
            _model.Type = textBox2.Text;
            _model.Year = textBox3.Text;
            _model.Color = textBox4.Text;
            _model.Plate = textBox5.Text;
            _model.Price = textBox6.Text;
            _model.Status = comboBox1.SelectedItem.ToString();
            _model.CategoryID = Convert.ToInt32(comboBox2.SelectedValue);
            _model.updateVehicleData();
            Clear();
            loadDataGridData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            _model.deleteVehicleData();
            Clear();
            loadDataGridData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            _model.VehicleID = -1;
            Clear();
        }
    }
}
