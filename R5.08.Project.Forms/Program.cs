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
            bool v_ConnectionStatus = DatabaseConnection.OpenConnection(ConnectionString.GetConnectionString());
            if (v_ConnectionStatus)
            {
                MessageBox.Show("Connexion réussie à la base de données !");

            }
            else
            {
                MessageBox.Show("La connexion à la base de données a échoué !");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm());
        }
    }
}