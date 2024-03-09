using System.Drawing.Drawing2D;
using Model = R5._08.Project.Forms.Models;

namespace ProjetForm
{
    public static class Puissance4Manager
    {
        public const int BOARD_NUMBER_LINE = 6;
        public const int BOARD_NUMBER_COLUMN = 7;

        /// <summary>
        /// Crée un pion
        /// </summary>
        /// <param name="p_Puissance4"> La partie de puissance4</param>
        /// <returns>Le pion</returns>
        public static PictureBox CreatePawn(Model.Puissance4 p_Puissance4)
        {
            if (p_Puissance4.m_CurrentPlayer == 0)
                return CreatePawn(Color.Red);
            return CreatePawn(Color.Yellow);
        }

        /// <summary>
        /// Crée un pion
        /// </summary>
        /// <param name="p_Color">La couleur du pion</param>
        /// <returns>Le pion</returns>
        private static PictureBox CreatePawn(Color p_Color)
        {
            PictureBox v_PBBoxPawn = new();

            // Création d'une bitmap
            Bitmap v_Bitmap = new(32, 32);

            // Création d'un objet graphics pour dessiner dessus
            Graphics v_Graphics = Graphics.FromImage(v_Bitmap);

            // Ecriture sur l'objet
            LinearGradientBrush v_LinearGradientBrush = new(new Rectangle(0, 0, 40, 30), p_Color, Color.White, -45, false);

            // Remplissage
            v_Graphics.FillEllipse(v_LinearGradientBrush, 0, 0, v_Bitmap.Size.Width, v_Bitmap.Size.Height);

            // Attribution
            v_PBBoxPawn.Image = v_Bitmap;
            v_PBBoxPawn.SizeMode = PictureBoxSizeMode.StretchImage;

            return v_PBBoxPawn;
        }

        /// <summary>
        /// Retour la position du pion
        /// </summary>
        /// <param name="p_Puissance4">La partie de puissance4</param>
        /// <param name="p_PawnColmunPosition">La colonne choisi par le joueur</param>
        /// <returns>La position du pion (retourn (-1, -1) s'il n'y a pas d'emplacement libre)</returns>
        public static Point GetPawnPosition(Puissance4 p_Puissance4, int p_PawnColmunPosition)
        {
            int v_PawnLinePosition = 5;
            bool v_PawnLinePositionFind = false;
            int v_PawnColmunPosition = p_PawnColmunPosition - 1;

            while (!v_PawnLinePositionFind && v_PawnLinePosition >= 0)
            {
                if (p_Puissance4.GetBoard()[v_PawnLinePosition, v_PawnColmunPosition])
                {
                    v_PawnLinePosition--;
                }
                else
                {
                    v_PawnLinePositionFind = true;
                }
            }

            if (v_PawnLinePositionFind)
                return new Point(v_PawnColmunPosition, v_PawnLinePosition);

            return new Point(-1, -1);
        }

        /// <summary>
        /// Retourne vrai ou faux si le joueur a gagné ou non
        /// </summary>
        /// <param name="p_PawnOnBoard">Les pions posés par le joueur</param>
        /// <returns>Vrai ou faux si le joueur a gagné ou non</returns>
        private static bool CheckIfWin(bool[,] p_PawnOnBoard)
        {
            if (CheckIfWinLine(p_PawnOnBoard)) return true;
            if (CheckIfWinColumn(p_PawnOnBoard)) return true;
            if (CheckIfWinDiagonal(p_PawnOnBoard)) return true;

            return false;
        }

        /// <summary>
        /// Retourne vrai ou faux si le joueur a alligner 4 pions sur une ligne
        /// </summary>
        /// <param name="p_PawnOnBoard">Les pions posés par le joueur</param>
        /// <returns> Vrai ou faux si le joueur a alligner 4 pions sur une ligne </returns>
        private static bool CheckIfWinLine(bool[,] p_PawnOnBoard)
        {
            bool v_PlayerWin = false;

            for (int v_Line = BOARD_NUMBER_LINE - 1; v_Line >= 0 && !v_PlayerWin; v_Line--)
            {
                int v_NbrOfPawnInARow = 0;

                for (int v_Column = 0; v_Column < BOARD_NUMBER_COLUMN && !v_PlayerWin; v_Column++)
                {
                    if (p_PawnOnBoard[v_Line, v_Column])
                    {
                        v_NbrOfPawnInARow++;
                        if (v_NbrOfPawnInARow == 4)
                            v_PlayerWin = true;
                    }
                    else
                    {
                        v_NbrOfPawnInARow = 0;
                    }
                }
            }

            return v_PlayerWin;
        }

        /// <summary>
        /// Retourne vrai ou faux si le joueur a alligner 4 pions sur une colonne
        /// </summary>
        /// <param name="p_PawnOnBoard">Les pions posés par le joueur</param>
        /// <returns> Vrai ou faux si le joueur a alligner 4 pions sur une colonne </returns>
        private static bool CheckIfWinColumn(bool[,] p_PawnOnBoard)
        {
            bool v_PlayerWin = false;

            for (int v_Column = 0; v_Column < BOARD_NUMBER_COLUMN && !v_PlayerWin; v_Column++)
            {
                int v_NbrOfPawnInARow = 0;

                for (int v_Line = BOARD_NUMBER_LINE - 1; v_Line >= 0 && !v_PlayerWin; v_Line--)
                {
                    if (p_PawnOnBoard[v_Line, v_Column])
                    {
                        v_NbrOfPawnInARow++;
                        if (v_NbrOfPawnInARow == 4)
                            v_PlayerWin = true;
                    }
                    else
                    {
                        v_NbrOfPawnInARow = 0;
                    }
                }
            }

            return v_PlayerWin;
        }

        /// <summary>
        /// Retourne vrai ou faux si le joueur a alligner 4 pions sur une diagonale
        /// </summary>
        /// <param name="p_PawnOnBoard">Les pions posés par le joueur</param>
        /// <returns> Vrai ou faux si le joueur a alligner 4 pions sur une diagonale </returns>
        private static bool CheckIfWinDiagonal(bool[,] p_PawnOnBoard)
        {
            bool v_PlayerWin = false;

            for (int v_Line = BOARD_NUMBER_LINE - 1; v_Line >= 0 && !v_PlayerWin; v_Line--)
            {
                for (int v_Column = 0; v_Column < BOARD_NUMBER_COLUMN && !v_PlayerWin; v_Column++)
                {
                    v_PlayerWin = CheckIfWinDiagonalBotLeftToTopRight(p_PawnOnBoard, v_Line, v_Column);
                    if (!v_PlayerWin)
                        v_PlayerWin = CheckIfWinDiagonalBotRightToTopLeft(p_PawnOnBoard, v_Line, v_Column);
                }
            }

            return v_PlayerWin;
        }

        /// <summary>
        /// Retourne vrai ou faux si le joueur a alligner 4 pions sur une diagonale
        /// (vérifie les diagonales qui commencent en bas à gauche et finissent en haut à droite)
        /// </summary>
        /// <param name="p_PawnOnBoard">Les pions posés par le joueur</param>
        /// <returns> Vrai ou faux si le joueur a alligner 4 pions sur une diagonale </returns>
        private static bool CheckIfWinDiagonalBotLeftToTopRight(bool[,] p_PawnOnBoard, int p_Line, int p_Column)
        {
            int v_NbrOfPawnInARow = 0;

            for (int v_Diagonal = 0; v_Diagonal < 4; v_Diagonal++)
            {
                if (p_Line - v_Diagonal > -1 && p_Column + v_Diagonal < 7)
                {
                    if (p_PawnOnBoard[p_Line - v_Diagonal, p_Column + v_Diagonal])
                    {
                        v_NbrOfPawnInARow++;
                    }
                }
            }

            return v_NbrOfPawnInARow == 4;
        }

        /// <summary>
        /// Retourne vrai ou faux si le joueur a alligner 4 pions sur une diagonale
        /// (vérifie les diagonales qui commencent en bas à droite et finissent en haut à gauche)
        /// </summary>
        /// <param name="p_PawnOnBoard">Les pions posés par le joueur</param>
        /// <returns> Vrai ou faux si le joueur a alligner 4 pions sur une diagonale </returns>
        private static bool CheckIfWinDiagonalBotRightToTopLeft(bool[,] p_PawnOnBoard, int p_Line, int p_Column)
        {
            int v_NbrOfPawnInARow = 0;

            for (int v_Diagonal = 0; v_Diagonal < 4; v_Diagonal++)
            {
                if (p_Line - v_Diagonal > -1 && p_Column - v_Diagonal > -1)
                {
                    if (p_PawnOnBoard[p_Line - v_Diagonal, p_Column - v_Diagonal])
                    {
                        v_NbrOfPawnInARow++;
                    }
                }
            }

            return v_NbrOfPawnInARow == 4;
        }
    }
}