using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace E_Transport.config
{
    internal class Connection: Services
    {
        MySqlConnection conn;
        MySqlCommand command;
        MySqlDataAdapter adapter;

        string stringConnection = "server=localhost;port=3306;database=showroom;uid=root;pwd=''";

        public Connection()
        {
            this.conn = new MySqlConnection(stringConnection);
            this.command = new MySqlCommand();
            this.adapter = new MySqlDataAdapter ();
        }

        void openConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    Console.WriteLine("[SUKSES] Koneksi ke database berhasil!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void closeConnection()
        {
            this.conn.Close();
        }

        public override int isNotQueryExecution(string query)
        {
            int result = -1;

            try
            {
                openConnection();
                command.Connection = this.conn;
                command.CommandText = query;
                result = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return result;
        }

        public override DataTable queryExecution(string query)
        {
            DataTable result = new DataTable();
            try
            {
                openConnection();
                command.Connection = this.conn;
                command.CommandText = query;
                adapter.SelectCommand = command;
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return result;
        }
    }
}
