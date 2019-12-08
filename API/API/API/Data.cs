using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace API
{
    public class Data
    {
        private string dbName = "ceis400";
        private string password = "password";
        private string username = "root";
        private string server = "localhost";
        private MySqlConnection connection = null;

        public Data()
        {
            string connectionString = string.Format(@"Server={0}; database={1}; UID={2}; password={3}", server, dbName, username, password);
            connection = new MySqlConnection(connectionString);
        }

        private void openData()
        {
            connection.Open();
        }

        private void closeData()
        {
            connection.Close();
        }

        public List<Dictionary<string, string>> runSql(string query)
        {
            openData();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Dictionary<string, string> tempDict = new Dictionary<string, string>();
                int columns = dataReader.FieldCount;
                for(int i = 0; i < columns; i++)
                {
                    tempDict.Add(dataReader.GetName(i), dataReader.GetString(i));
                }
                result.Add(tempDict);
            }
            closeData();
            return result;
        }
    }
}
