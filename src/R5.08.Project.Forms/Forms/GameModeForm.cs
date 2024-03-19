using R5._08.Project.Database.Interface;
using R5._08.Project.Forms.Models;

namespace ProjetForm
{
    public partial class GameModeForm : Form
    {
        private IUnitOfWork m_UnitOfWork;
        public GameModeForm(IUnitOfWork p_UnitOfWork)
        {
            m_UnitOfWork = p_UnitOfWork;
            InitializeComponent();
        }

        public void RadioButtonPlayerVsPlayer_CheckedChanged(object p_Sender, EventArgs p_EventArgs)
        {
            // Affichage (ou non) des groupBox en fonction des radioButtons
            m_GroupBoxGameModePlayerVSPlayerInput1.Visible = true;
            m_GroupBoxGameModePlayerVSPlayerInput2.Visible = false;
        }

        public void RadioButtonPlayerVsIA_CheckedChanged(object p_Sender, EventArgs p_EventArgs)
        {
            // Affichage (ou non) des groupBox en fonction des radioButtons
            m_GroupBoxGameModePlayerVSPlayerInput1.Visible = false;
            m_GroupBoxGameModePlayerVSPlayerInput2.Visible = true;
        }

        public void BtnGameModeBack_Click(object p_Sender, EventArgs p_EventArgs)
        {

            Hide();

            // Réouvre la page Home
            HomeForm v_HomeForm = new HomeForm(m_UnitOfWork);
            v_HomeForm.ShowDialog();
        }

        public void InputPseudoPlayer1_Enter(object p_Sender, EventArgs p_EventArgs)
        {
            if (m_InputPseudoPlayer1.Text.Equals("Joueur 1"))
            {
                m_InputPseudoPlayer1.Clear();
            }
        }

        public void InputPseudoPlayer2_Enter(object p_Sender, EventArgs p_EventArgs)
        {
            if (m_InputPseudoPlayer2.Text.Equals("Joueur 2"))
            {
                m_InputPseudoPlayer2.Clear();
            }
        }

        public void InputPseudoPlayer_Enter(object p_Sender, EventArgs p_EventArgs)
        {
            if (m_InputPseudoPlayer.Text.Equals("Pseudo"))
            {
                m_InputPseudoPlayer.Clear();
            }
        }

        public void BtnGameModePlay_Click(object p_Sender, EventArgs p_EventArgs)
        {

            if (m_RadioButtonPlayerVSPlayer.Checked)
            {
                bool v_PseudoAreCorrect = CheckPseudoPlayerVSPlayer();
                if (v_PseudoAreCorrect)
                {
                    StartGame();
                }
            }
            else if (m_RadioButtonPlayerVSAi.Checked)
            {
                bool v_PseudoAreCorrect = CheckPseudoPlayerVSAi();
                if (v_PseudoAreCorrect)
                {
                    StartGame();
                }
            }
        }

        public bool CheckPseudoPlayerVSPlayer()
        {
            bool v_PseudoAreCorrect = true;

            if (m_InputPseudoPlayer1.Text.Length <= 0)
            {
                m_ErrorProviderInputPseudoPlayer1.SetError(m_InputPseudoPlayer1, "Le pseudo ne peut pas être vide !");
                v_PseudoAreCorrect = false;
            }
            else if (m_InputPseudoPlayer1.Text.Length > 10)
            {
                m_ErrorProviderInputPseudoPlayer1.SetError(m_InputPseudoPlayer1, "Le pseudo ne peut pas excéder 10 caractères !");
                v_PseudoAreCorrect = false;
            }
            else
            {
                m_ErrorProviderInputPseudoPlayer1.SetError(m_InputPseudoPlayer1, "");
            }

            if (m_InputPseudoPlayer2.Text.Length <= 0)
            {
                m_ErrorProviderInputPseudoPlayer2.SetError(m_InputPseudoPlayer2, "Le pseudo ne peut pas être vide !");
                v_PseudoAreCorrect = false;
            }
            else if (m_InputPseudoPlayer2.Text.Length > 10)
            {
                m_ErrorProviderInputPseudoPlayer2.SetError(m_InputPseudoPlayer2, "Le pseudo ne peut pas excéder 10 caractères !");
                v_PseudoAreCorrect = false;
            }
            else
            {
                m_ErrorProviderInputPseudoPlayer2.SetError(m_InputPseudoPlayer2, "");
            }

            return v_PseudoAreCorrect;
        }

        public bool CheckPseudoPlayerVSAi()
        {
            bool v_PseudoAreCorrect = true;

            if (m_InputPseudoPlayer.Text.Length <= 0)
            {
                m_ErrorProviderInputPseudoPlayer.SetError(m_InputPseudoPlayer, "Le pseudo ne peut pas être vide !");
                v_PseudoAreCorrect = false;
            }
            else if (m_InputPseudoPlayer.Text.Length > 10)
            {
                m_ErrorProviderInputPseudoPlayer.SetError(m_InputPseudoPlayer, "Le pseudo ne peut pas excéder 10 caractères !");
                v_PseudoAreCorrect = false;
            }
            else
            {
                m_ErrorProviderInputPseudoPlayer.SetError(m_InputPseudoPlayer, "");
            }

            return v_PseudoAreCorrect;
        }

        public void StartGame()
        {
            Hide();

            Puissance4 v_Puissance4 = new();
            if (m_RadioButtonPlayerVSPlayer.Checked)
            {
                v_Puissance4.m_Joueur1 = m_InputPseudoPlayer1.Text;
                v_Puissance4.m_Joueur2 = m_InputPseudoPlayer2.Text;
            }
            else
            {
                // Récupérer le niveau de difficulté de l'IA, 0 -> Easy, 1 -> Normal, 2 -> Hard
                int v_NiveauIa = m_RadioButtonModeEasy.Checked ? 0 : (m_RadioButtonModeNormal.Checked ? 1 : 2);
                v_Puissance4.m_IaStart = m_CheckBoxIaStart.Checked;
                if (m_CheckBoxIaStart.Checked)
                {
                    v_Puissance4.m_Joueur2 = m_InputPseudoPlayer1.Text.StartsWith("IA ") ? m_InputPseudoPlayer1.Text.Replace("IA ", "ia") : m_InputPseudoPlayer.Text;
                    v_Puissance4.m_Joueur1 = v_NiveauIa == 0 ? "IA Facile" : (v_NiveauIa == 1 ? "IA Normale" : "IA Difficile");
                }
                else
                {
                    v_Puissance4.m_Joueur1 = m_InputPseudoPlayer1.Text.StartsWith("IA ") ? m_InputPseudoPlayer1.Text.Replace("IA ", "ia") : m_InputPseudoPlayer.Text;
                    v_Puissance4.m_Joueur2 = v_NiveauIa == 0 ? "IA Facile" : (v_NiveauIa == 1 ? "IA Normale" : "IA Difficile");
                }
                v_Puissance4.m_difficulty = v_NiveauIa;
            }

            // Ouverture du plateau de jeu
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWork);
            v_PlateauForm.ShowDialog();
        }
    }
}