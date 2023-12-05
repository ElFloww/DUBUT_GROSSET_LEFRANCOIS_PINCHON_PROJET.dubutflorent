using DB = R5._08.Project.Database.DatabaseConnection;
using MySqlConnector;

namespace ProjetForm
{
    public partial class ScoresForm : Form
    {
        public ScoresForm()
        {
            InitializeComponent();
        }

        private void btnGameModeBack_Click(object p_Sender, EventArgs p_EventArgs)
        {
            
            Hide();

            // Ouverture de la page Home
            HomeForm v_HomeForm = new();
            v_HomeForm.ShowDialog();
        }

        private void ScoresForm_Load(object sender, EventArgs e)
        {
            /*Upgrade this initialisaiton*/
            this.scoresGridView.Columns.Add("Nom","Nom");
            this.scoresGridView.Columns.Add("Nombre de parties", "Nombre de parties");
            this.scoresGridView.Columns.Add("Nombre de parties gagnées", "Nombre de parties gagnées");
            this.scoresGridView.Columns.Add("Temps de jeu moyen", "Temps de jeu moyen");
            try
            {
                string v_Query = $"SELECT * FROM Scoreboard";
                MySqlCommand v_Command = new(v_Query, DB.m_DBConnection);
                MySqlDataReader v_DataReader = v_Command.ExecuteReader();
                while(v_DataReader.Read())
                {
                    this.scoresGridView.Rows.Add(v_DataReader.GetString(1), v_DataReader.GetInt32(2), v_DataReader.GetInt32(3), v_DataReader.GetInt32(4));
                }
                v_DataReader.Close();
                v_Command.Dispose();
            }
            catch(Exception v_Ex)
            {
                Console.WriteLine(v_Ex.ToString());
            }
        }
    }
}