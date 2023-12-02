using MySqlConnector;

namespace R5._08.Project.Database
{
    public static class DatabaseConnection
    {
        public static MySqlConnection? m_DBConnection;

        public static bool OpenConnection(string p_ConnectionString)
        {
            m_DBConnection = new MySqlConnection(p_ConnectionString);
            try
            {
                m_DBConnection.Open();
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
            if (m_DBConnection != null && m_DBConnection.State == System.Data.ConnectionState.Open)
            {
                m_DBConnection.Close();
                v_Result = true;
            }
            return v_Result;
        }
    }
}