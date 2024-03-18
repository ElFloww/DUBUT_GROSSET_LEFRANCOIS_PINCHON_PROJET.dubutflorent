using R5._08.Project.Database.Interface;

namespace ProjetForm
{
    public partial class HomeForm : Form
    {
        private IUnitOfWork m_UnitOfWork;
        public HomeForm(IUnitOfWork p_UnitOfWork)
        {
            m_UnitOfWork = p_UnitOfWork;
            InitializeComponent();
        }

        public void BtnHomePlay_Click(object p_Sender, EventArgs p_EventArgs)
        {
            // Cache l'écran principal pour se rediriger vers les modes de jeu
            Hide();
            GameModeForm v_GameModeForm = new(m_UnitOfWork);
            v_GameModeForm.ShowDialog();
        }

        public void BtnHomeQuit_Click(object p_Sender, EventArgs p_EventArgs)
        {
            // Fermeture de l'application
            Application.Exit();
        }

        public void BtnHomeScores_Click(object p_Sender, EventArgs p_EventArgs)
        {
            // On cache la page
            Hide();

            // Ouverture de la page de scores
            ScoresForm v_ScoresForm = new(m_UnitOfWork);
            v_ScoresForm.ShowDialog();
        }
    }
}