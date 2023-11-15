using R5._08.Project.Database;
using System;
using System.Windows.Forms;

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
            //Connection à la base de données
            bool connexionOuverte = DatabaseConnection.OpenConnection();
            if (connexionOuverte)
            {
                MessageBox.Show("Connexion à la base réussi !");

            }
            else
            {
                MessageBox.Show("Echec de connexion à la base !");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm());
        }
    }
}