using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using E_Showroom.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace E_Showroom.view
{
    public partial class SalesmentView : UserControl
    {
        private SaleModel _model;
        public SalesmentView()
        {
            InitializeComponent();
            _model = new SaleModel();
            loadDataGridData();
            loadVehicleList();
            loadUserList();
            loadClientList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int price))
            {
                MessageBox.Show("Harga Jual harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            _model.TanggalPenjualan = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            _model.HargaJual = price.ToString();
            _model.IdKendaraan = comboBox3.SelectedValue.ToString();
            _model.MetodePembayaran = comboBox4.SelectedItem.ToString();
            _model.IdUser= comboBox1.SelectedValue.ToString();
            _model.IdPelanggan = comboBox2.SelectedValue.ToString();
            _model.simpanData();
            Clear();
            loadDataGridData();
        }

        void Clear()
        {
            comboBox1.SelectedValue = -1;
            comboBox2.SelectedValue = -1;
            comboBox3.SelectedValue = -1;
            comboBox4.SelectedItem = -1;
            textBox2.Clear();
            _model.IdPenjualan = "-1";
        }

        void loadDataGridData()
        {
            DataTable dt = _model.tampilSemua();

            tabelPelanggan.DataSource = dt;

            tabelPelanggan.RowPostPaint += (sender, e) => {
                tabelPelanggan.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
            };
        }

        void loadUserList()
        {
            try
            {
                comboBox1.Items.Clear();
                DataTable dt = _model.getPengguna();
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "username";
                comboBox1.ValueMember = "id_user";
                comboBox1.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data kategori: " + ex.Message);
            }
        }
        void loadVehicleList()
        {
            try
            {
                comboBox3.Items.Clear();
                DataTable dt = _model.getKendaraan();
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "nama_kendaraan";
                comboBox3.ValueMember = "id_kendaraan";
                comboBox3.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data kategori: " + ex.Message);
            }
        }
        void loadClientList()
        {
            try
            {
                comboBox2.Items.Clear();
                DataTable dt = _model.getPelanggan();
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "nama";
                comboBox2.ValueMember = "id_pelanggan";
                comboBox2.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data kategori: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _model.hapusData();
            loadDataGridData();
            Clear();
        }

        private void tabelPelanggan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = this.tabelPelanggan.Rows[e.RowIndex];

                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["tanggal_penjualan"].Value);
                textBox2.Text = row.Cells["harga_jual"].Value?.ToString();

                if (row.Cells["id_user"].Value != null)
                {
                    comboBox1.SelectedValue = row.Cells["id_user"].Value;
                }
                if (row.Cells["id_pelanggan"].Value != null)
                {
                    comboBox2.SelectedValue = row.Cells["id_pelanggan"].Value;
                }
                if (row.Cells["id_kendaraan"].Value != null)
                {
                    comboBox3.SelectedValue = row.Cells["id_kendaraan"].Value;
                }
                if (row.Cells["metode_pembayaran"].Value != null)
                {
                    comboBox4.SelectedItem = row.Cells["metode_pembayaran"].Value.ToString();
                }

                if (row.Cells["id_penjualan"].Value != null &&
                    int.TryParse(row.Cells["id_penjualan"].Value.ToString(), out int salesmentID))
                {
                    _model.IdPenjualan = salesmentID.ToString();
                }
                else
                {
                    MessageBox.Show("ID Penjualan tidak valid.");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null ||
                comboBox2.SelectedValue == null ||
                comboBox3.SelectedValue == null ||
                comboBox4.SelectedItem == null ||
                string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Harap lengkapi semua data sebelum menyimpan.", "Input Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Hentikan eksekusi method jika ada data yang kosong
                }
            _model.TanggalPenjualan = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            _model.HargaJual = textBox2.Text;
            _model.IdKendaraan = comboBox3.SelectedValue.ToString();
            _model.MetodePembayaran = comboBox4.SelectedItem.ToString();
            _model.IdUser = comboBox1.SelectedValue.ToString();
            _model.IdPelanggan = comboBox2.SelectedValue.ToString();
            _model.editData();
            Clear();
            loadDataGridData();
        }
    }
}
