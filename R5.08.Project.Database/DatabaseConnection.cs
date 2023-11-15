using MySqlConnector;

namespace R5._08.Project.Database
{
    public static class DatabaseConnection
    {
        public static MySqlConnection? DBConnection;

        public static bool OpenConnection()
        {
            DBConnection = new MySqlConnection(ConnectionString.GetConnectionString());
            try
            {
                DBConnection.Open();
                return true;
            }
            catch (Exception v_Ex)
            {
                Console.WriteLine(v_Ex.Message);
                return false;
            }
        }

        public static bool CloseConnection()
        {
            bool v_Result = false;
            if (DBConnection != null && DBConnection.State == System.Data.ConnectionState.Open)
            {
                DBConnection.Close();
                v_Result = true;
            }
            return v_Result;
        }
    }
}