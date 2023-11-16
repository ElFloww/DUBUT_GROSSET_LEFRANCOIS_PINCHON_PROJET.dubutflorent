using R5._08.Project.Database;

namespace ProjetForm
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Connection to the database
            bool v_ConnectionStatus = DatabaseConnection.OpenConnection();
            if (v_ConnectionStatus)
            {
                MessageBox.Show("Successful connection to the database !");

            }
            else
            {
                MessageBox.Show("Connection to the database failed !");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm());
        }
    }
}