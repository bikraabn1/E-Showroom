using System;
using System.Data;
using E_Showroom.config;

namespace E_Showroom.model
{

    public enum UserStatus
    {
        OK,
        NotFound,
        AlreadyUsed
    }

    public class UserCheckResult
    {
        public UserStatus Status { get; set; }
        public int UserId { get; set; }
    }
    internal class ClientModel
    {
        private int _client_id;
        private int _user_id;
        private string _name;
        private string _ktp;
        private string _telepon;
        private string _address;

        Connection server;
        string query;

        public ClientModel()
        {
            _user_id = 0;
            _client_id = 0;
            _name = "";
            _ktp = "";
            _telepon = "";
            _address = "";

            this.query = "";
            this.server = new Connection();
        }

        public int ClientID
        {
            set { _client_id = value; }
        }
        public int UserID
        {
            set { _user_id = value; }
        }
        public string Name
        {
            set { _name = value; }
        }
        public string KTP
        {
            set { _ktp = value; }
        }
        public string Telepon
        {
            set { _telepon = value; }
        }
        public string Address
        {
            set { _address = value; }
        }

        public DataTable getClientDatas()
        {
            query = "SELECT " +
            "   p.id_pelanggan, " +
            "   p.nama, " +
            "   p.no_ktp, " +
            "   p.telepon, " +
            "   p.alamat, " +
            "   p.id_user, " +
            "   u.username " +
            "FROM pelanggan p " +
            "JOIN user u on p.id_user = u.id_user";

            return server.queryExecution(query);
        }

        public DataTable getUserDataList()
        {
            query = "select * from user";
            return server.queryExecution(query);
        }

        public UserCheckResult getUserDataByUsername(string username)
        {
            string query = "select username, id_user from user where username = '" + username + "'";
            DataTable result = server.queryExecution(query);

            if (result.Rows.Count == 0)
            {
                return new UserCheckResult { Status = UserStatus.NotFound };
            }

            int userId = Convert.ToInt32(result.Rows[0]["id_user"]);
            string checkQuery = "SELECT 1 FROM pelanggan WHERE id_user = '" + userId + "'";
            DataTable checkIsUserExist = server.queryExecution(checkQuery);

            if (checkIsUserExist.Rows.Count > 0)
            {
                return new UserCheckResult { Status = UserStatus.AlreadyUsed };
            }

            return new UserCheckResult { Status = UserStatus.OK, UserId = userId };

        }

        public string getTotalClient()
        {
            query = "SELECT COUNT(*) FROM pelanggan";
            DataTable result = server.queryExecution(query);

            if (result != null && result.Rows.Count > 0)
            {
                return result.Rows[0][0].ToString();
            }
            return "0";
        }

        public int insertClientData()
        {
            int result = -1;
            query = "insert into pelanggan(nama, no_ktp, telepon, alamat, id_user) values('" + _name + "','" + _ktp + "','" + _telepon + "','" + _address + "','" + _user_id + "')";

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

        public int updateClientData()
        {
            int result = -1;
            query = "update pelanggan set nama='" + _name + "', no_ktp='" + _ktp + "', telepon='" + _telepon + "', alamat='" + _address + "', id_user='" + _user_id + "' where id_pelanggan='" + _client_id + "' ";

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

        public int deleteClientData()
        {
            int result = -1;
            query = "delete from pelanggan where id_pelanggan='" + _client_id + "' ";

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
