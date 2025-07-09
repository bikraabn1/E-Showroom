using System;
using System.Data;
using E_Showroom.config;

namespace E_Showroom.model
{
    internal class VehicleModel
    {
        private int _vehicle_id;
        private int _category_id;
        private string _merk;
        private string _type;
        private string _year;
        private string _color;
        private string _plate;
        private string _price;
        private string _status;

        Connection server;
        string query;

        public VehicleModel()
        {
            _vehicle_id = 0;
            _category_id = 0;
            _merk = "";
            _type = "";
            _year = "";
            _color = "";
            _plate = "";
            _price = "";
            _status = "";

            this.query = "";
            this.server = new Connection();
        }

        public int VehicleID
        {
            set { _vehicle_id = value; }
        }
        public int CategoryID
        {
            set { _category_id = value; }
        }
        public string Merk
        {
            set { _merk = value; }
        }
        public string Type
        {
            set { _type = value; }
        }public string Year
        {
            set { _year = value; }
        }
        public string Plate
        {
            set { _plate = value; }
        }
        public string Price
        {
            set { _price = value; }
        }
        public string Color
        {
            set { _color = value; }
        }
        public string Status
        {
            set { _status = value; }
        }

        public DataTable getVehicleDatas()
        {
            query = "SELECT " +
            "   k.id_kendaraan, " +
            "   k.merk, " +
            "   k.tipe, " +
            "   k.tahun, " +
            "   k.warna, " +
            "   k.nomor_polisi, " +
            "   k.harga, " +
            "   k.status, " +
            "   kk.nama_kategori, " + 
            "   k.id_kategori " +
            "FROM kendaraan k " +
            "JOIN kategori_kendaraan kk ON k.id_kategori = kk.id_kategori";
            return server.queryExecution(query);
        }

        public DataTable getCategoryList()
        {
            query = "select * from kategori_kendaraan";
            return server.queryExecution(query);
        }

        public string getTotalVehicle()
        {
            query = "SELECT COUNT(*) FROM kendaraan";
            DataTable result = server.queryExecution(query);

            if (result != null && result.Rows.Count > 0)
            {
                return result.Rows[0][0].ToString();
            }
            return "0";
        }

        public int insertVehicleData()
        {
            int result = -1;
            query = "insert into kendaraan(merk, tipe, tahun, warna, nomor_polisi, harga, status, id_kategori) values('" + _merk + "','" + _type + "','" + _year + "','" + _color + "','" + _plate + "','" + _price + "','" + _status + "','" + _category_id + "')";

            try
            {
                result = server.isNotQueryExecution(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public int updateVehicleData()
        {
            int result = -1;
            query = "update kendaraan set merk='" + _merk + "', tipe='" + _type + "', tahun=" + _year + ", warna='" + _color + "', nomor_polisi='" + _plate + "', harga=" + _price + ", status='" + _status + "', id_kategori=" + _category_id + " where id_kendaraan=" + _vehicle_id + " ";

            try
            {
                result = server.isNotQueryExecution(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public int deleteVehicleData()
        {
            int result = -1;
            query = "delete from kendaraan where id_kendaraan='" + _vehicle_id + "' ";

            try
            {
                result = server.isNotQueryExecution(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
