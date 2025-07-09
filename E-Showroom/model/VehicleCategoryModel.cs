using System;
using System.Data;
using E_Showroom.config;

namespace E_Showroom.model
{
    internal class VehicleCategoryModel
    {
        private int _category_id;
        private string _category_name;

        Connection server;
        string query;

        public VehicleCategoryModel()
        {
            _category_id = 0;
            _category_name = "";

            this.query = "";
            this.server = new Connection();
        }

        public int CategoryID
        {
            set { _category_id = value; }
        }
        public string CategoryName
        {
            set { _category_name = value; }
        }

        public DataTable getCategoryDatas()
        {
            query = "select * from kategori_kendaraan";
            return server.queryExecution(query);
        }

        public string getTotalCategory()
        {
            query = "SELECT COUNT(*) FROM kategori_kendaraan";
            DataTable result = server.queryExecution(query);

            if (result != null && result.Rows.Count > 0)
            {
                return result.Rows[0][0].ToString();
            }
            return "0";
        }

        public int insertCategoryData()
        {
            int result = -1;
            query = "insert into kategori_kendaraan(nama_kategori) values('" + _category_name + "')";

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

        public int updateCategoryData()
        {
            int result = -1;
            query = "update kategori_kendaraan set nama_kategori='" + _category_name + "' where id_kategori='" + _category_id + "' ";

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

        public int deleteCategoryData()
        {
            int result = -1;
            query = "delete from kategori_kendaraan where id_kategori='" + _category_id + "' ";

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
