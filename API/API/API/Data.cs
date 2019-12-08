using System;
using System.Collections.Generic;
using System.Data;
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
            string connectionString = string.Format(@"Server={0}; database={1}; UID={2}; password={3}; Allow User Variables=True", server, dbName, username, password);
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

        public Dictionary<string, string> runStoredProcedure(string storedProc, Dictionary<string, string> inputs, Dictionary<string, MySqlDbType> outputs)
        {
            openData();
            Dictionary<string, string> results = new Dictionary<string, string>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = storedProc;
            command.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, string> input in inputs)
            {
                command.Parameters.AddWithValue(input.Key, input.Value);
                command.Parameters[input.Key].Direction = ParameterDirection.Input;
            }

            foreach (KeyValuePair<string, MySqlDbType> output in outputs)
            {
                command.Parameters.AddWithValue(output.Key, output.Value);
                command.Parameters[output.Key].Direction = ParameterDirection.Output;
                results.Add(output.Key, "");
            }

            command.ExecuteNonQuery();

            foreach(KeyValuePair<string, string> result in results)
            {
                results[result.Key] = command.Parameters[result.Key].Value.ToString();
            }

            closeData();
            return results;
        }
    }
}
