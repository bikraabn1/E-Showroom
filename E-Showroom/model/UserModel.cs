using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Showroom.config;

namespace E_Showroom.model
{
    internal class UserModel
    {
        private int _user_id;
        private string _name;
        private string _username;
        private string _password;

        Connection server;
        string query;

        public UserModel()
        {
            _user_id = 0;
            _name = "";
            _username = "";
            _password = "";

            this.query = "";
            this.server = new Connection();
        }

        public int UserID
        {
            set { _user_id = value; }
        }
        public string Name
        {
            set { _name = value; }
        }
        public string UserName
        {
            set { _username = value; }
        }
        public string Password
        {
            set { _password = value; }
        }

        public DataTable getUserDatas()
        {
            query = "select * from user";
            return server.queryExecution(query);
        }

        public string getTotalUser()
        {
            query = "SELECT COUNT(*) FROM user";
            DataTable result = server.queryExecution(query);

            if (result != null && result.Rows.Count > 0)
            {
                return result.Rows[0][0].ToString();
            }
            return "0";
        }

        public int insertUserData()
        {
            int result = -1;
            query = "insert into user(nama, username, password) values('" + _name + "','" + _username + "','" + _password + "')";

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
