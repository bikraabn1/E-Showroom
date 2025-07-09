using System;
using System.Data;
using E_Showroom.config;

namespace E_Showroom.model
{
    internal class SaleModel
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

        public SaleModel()
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
        public int editData()
        {
            int hasil = -1;
            Query = "UPDATE penjualan SET " +
                    "id_kendaraan = '" + _id_kendaraan + "', " +
                    "id_user = '" + _id_user + "', " +
                    "id_pelanggan = '" + _id_pelanggan + "', " +
                    "tanggal_penjualan = '" + _tanggal_penjualan + "', " +
                    "harga_jual = '" + _harga_jual + "', " +
                    "metode_pembayaran = '" + _metode_pembayaran + "' " +
                    "WHERE id_penjualan = '" + _id_penjualan + "'";
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
        public int hapusData()
        {
            int hasil = -1;
            Query = "DELETE FROM penjualan WHERE id_penjualan = '" + _id_penjualan + "'";
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
            Query = @"
        SELECT 
            p.id_penjualan,
            p.id_kendaraan,
            p.id_user,
            p.id_pelanggan, 
            pl.nama AS nama_pelanggan,
            k.nomor_polisi,
            p.tanggal_penjualan, 
            p.harga_jual, 
            p.metode_pembayaran,
            u.username
        FROM 
            penjualan p
        JOIN 
            kendaraan k ON p.id_kendaraan = k.id_kendaraan
        JOIN 
            pelanggan pl ON p.id_pelanggan = pl.id_pelanggan
        JOIN 
            user u ON p.id_user = u.id_user";

            return server.queryExecution(Query);
        }

        // === Cari penjualan berdasarkan nama pelanggan (join) ===
        public DataTable tampilDgNamaPelanggan(string nama)
        {
            Query = "SELECT * FROM penjualan WHERE id_pelanggan LIKE '" + nama + "%'";
            return server.queryExecution(Query);
        }

        // === Get data kendaraan untuk combobox ===
        public DataTable getKendaraan()
        {
            Query = "SELECT CONCAT(merk, ' ', tipe) AS nama_kendaraan, id_kendaraan FROM kendaraan;";
            return server.queryExecution(Query);
        }

        // === Get data pelanggan untuk combobox ===
        public DataTable getPelanggan()
        {
            Query = "SELECT id_pelanggan, nama FROM pelanggan";
            return server.queryExecution(Query);
        }
        // === Get data pelanggan untuk combobox ===
        public DataTable getPengguna()
        {
            Query = "SELECT id_user, username FROM user";
            return server.queryExecution(Query);
        }

        public string getJumlahPenjualan()
        {
            Query = "select count(*) from penjualan"; 
            DataTable result = server.queryExecution(Query);

            if (result != null && result.Rows.Count > 0)
            {
                return result.Rows[0][0].ToString();
            }
            return "0";
        }
    }
}
