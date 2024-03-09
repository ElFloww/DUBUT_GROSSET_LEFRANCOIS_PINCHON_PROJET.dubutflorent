using R5._08.Project.Database;
using R5._08.Project.Database.Interface;
using R5._08.Project.Forms;

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

        private void btnHomePlay_Click(object p_Sender, EventArgs p_EventArgs)
        {
            // Cache l'écran principal pour se rediriger vers les modes de jeu
            Hide();
            GameModeForm v_GameModeForm = new(m_UnitOfWork);
            v_GameModeForm.ShowDialog();
        }

        private void btnHomeQuit_Click(object p_Sender, EventArgs p_EventArgs)
        {
            // Fermeture de l'application
            Application.Exit();
        }

        private void btnHomeScores_Click(object p_Sender, EventArgs p_EventArgs)
        {
            // On cache la page
            Hide();

            // Ouverture de la page de scores
            ScoresForm v_ScoresForm = new(m_UnitOfWork);
            v_ScoresForm.ShowDialog();
        }
    }
}