﻿using System;
using System.Data;
using System.Windows.Forms;
using E_Showroom.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace E_Showroom.view
{
    public partial class ClientView : UserControl
    {
        private ClientModel _model;
        public ClientView()
        {
            InitializeComponent();
            _model = new ClientModel();
            loadDataGridData();
        }

        void loadDataGridData()
        {
            DataTable dt = _model.getClientDatas();

            tabelPelanggan.DataSource = dt;

            tabelPelanggan.RowPostPaint += (sender, e) => {
                tabelPelanggan.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(textBox2.Text, out int no_ktp))
            {
                MessageBox.Show("Nomor KTP harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }
            if (!int.TryParse(textBox3.Text, out int telepon))
            {
                MessageBox.Show("Nomor Telepon harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            UserCheckResult result = _model.getUserDataByUsername(textBox5.Text);

            switch (result.Status)
            {
                case UserStatus.NotFound:
                    MessageBox.Show("Username tidak ditemukan.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Focus();
                    return;
                case UserStatus.AlreadyUsed:
                    MessageBox.Show("Username sudah digunakan", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Focus();
                    return;
            }


            _model.Name = textBox1.Text;
            _model.KTP = no_ktp.ToString();
            _model.Telepon = telepon.ToString();
            _model.Address = textBox4.Text; 
            _model.UserID = result.UserId;
            _model.insertClientData();
            Clear();
            loadDataGridData();
        }

        void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            _model.ClientID = -1;
        }

        private void tabelPelanggan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = this.tabelPelanggan.Rows[e.RowIndex];

                textBox1.Text = row.Cells["nama"].Value?.ToString();
                textBox2.Text = row.Cells["no_ktp"].Value?.ToString();
                textBox3.Text = row.Cells["telepon"].Value?.ToString();
                textBox4.Text = row.Cells["alamat"].Value?.ToString();

                if (row.Cells["id_user"].Value != null)
                {
                }

                if (row.Cells["id_pelanggan"].Value != null &&
                    int.TryParse(row.Cells["id_pelanggan"].Value.ToString(), out int clientID))
                {
                    _model.ClientID = clientID;
                }
                else
                {
                    MessageBox.Show("ID Kendaraan tidak valid.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _model.deleteClientData();
            Clear();
            loadDataGridData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _model.Name = textBox1.Text;
            _model.KTP = textBox2.Text;
            _model.Telepon = textBox3.Text;
            _model.Address = textBox4.Text;
            _model.updateClientData();
            Clear();
            loadDataGridData();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
