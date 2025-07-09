using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showroom.config;

namespace Showroom.model
{
    class Penjualan
    {
        private string _id_penjualan;
        private string _id_kendaraan;
        private string _id_user;
        private string _id_pelanggan;
        private string _tanggal_penjualan;
        private string _harga_jual;
        private string _metode_pembayaran;

        Connection server;
        string Query;

        public Penjualan()
        {
            _id_penjualan = "";
            _id_kendaraan = "";
            _id_user = "";
            _id_pelanggan = "";
            _tanggal_penjualan = "";
            _harga_jual = "";
            _metode_pembayaran = "";

            server = new Connection();
            Query = "";
        }

        // === Properti ===
        public string IdPenjualan { set { _id_penjualan = value; } }
        public string IdKendaraan { set { _id_kendaraan = value; } }
        public string IdUser { set { _id_user = value; } }
        public string IdPelanggan { set { _id_pelanggan = value; } }
        public string TanggalPenjualan { set { _tanggal_penjualan = value; } }
        public string HargaJual { set { _harga_jual = value; } }
        public string MetodePembayaran { set { _metode_pembayaran = value; } }

        // === Cek apakah data penjualan sudah ada ===
        public bool apakahAda(string id_penjualan)
        {
            bool cek = false;
            Query = "SELECT * FROM penjualan WHERE id_penjualan = '" + id_penjualan + "'";
            if (server.queryExecution(Query).Rows.Count > 0)
            {
                cek = true;
            }
            return cek;
        }

        // === Simpan Data ===
        public int simpanData()
        {
            int hasil = -1;
            Query = "INSERT INTO penjualan (id_kendaraan, id_user, id_pelanggan, tanggal_penjualan, harga_jual, metode_pembayaran) " +
                    "VALUES ('" + _id_kendaraan + "','" + _id_user + "','" + _id_pelanggan + "','" + _tanggal_penjualan + "','" + _harga_jual + "','" + _metode_pembayaran + "')";
            try
            {
                hasil = server.isNotQueryExecution(Query);
            }
            catch (Exception)
            {
                // log error
            }
            return hasil;
        }

        // === Update Data ===
        public int editData(string id_penjualan)
        {
            int hasil = -1;
            Query = "UPDATE penjualan SET " +
                    "id_kendaraan = '" + _id_kendaraan + "', " +
                    "id_user = '" + _id_user + "', " +
                    "id_pelanggan = '" + _id_pelanggan + "', " +
                    "tanggal_penjualan = '" + _tanggal_penjualan + "', " +
                    "harga_jual = '" + _harga_jual + "', " +
                    "metode_pembayaran = '" + _metode_pembayaran + "' " +
                    "WHERE id_penjualan = '" + id_penjualan + "'";
            try
            {
                hasil = server.isNotQueryExecution(Query);
            }
            catch (Exception)
            {
            }
            return hasil;
        }

        // === Hapus Data ===
        public int hapusData(string id_penjualan)
        {
            int hasil = -1;
            Query = "DELETE FROM penjualan WHERE id_penjualan = '" + id_penjualan + "'";
            try
            {
                hasil = server.isNotQueryExecution(Query);
            }
            catch (Exception)
            {
            }
            return hasil;
        }

        // === Ambil semua data penjualan ===

        public DataTable tampilSemua()
        {
            Query = @"SELECT id_penjualan, id_kendaraan, id_user, id_pelanggan, 
                     tanggal_penjualan, harga_jual, metode_pembayaran
              FROM penjualan";
            return server.queryExecution(Query);
        }

        // === Cari penjualan berdasarkan nama pelanggan (join) ===
        public DataTable tampilDgNamaPelanggan(string nama)
        {
            Query = "SELECT * FROM penjualan WHERE id_pelanggan LIKE '" + nama + "%'";
            return server.queryExecution(Query);
        }

        // === Get data kendaraan untuk combobox ===
        public DataTable getidkendaraan()
        {
            Query = "SELECT id_kendaraan, tipe FROM kendaraan";
            return server.queryExecution(Query);
        }

        // === Get data pelanggan untuk combobox ===
        public DataTable getPelanggan()
        {
            Query = "SELECT id_pelanggan, nama FROM pelanggan";
            return server.queryExecution(Query);
        }
    }
}
