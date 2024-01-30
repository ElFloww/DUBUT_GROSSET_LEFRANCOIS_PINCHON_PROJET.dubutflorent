using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R5._08.Project.Forms.Models
{
    public class puissance4: ICloneable
    {
        public Grid grid = new Grid();

        public List<int> v_NbPawnByRow = new List<int>();
        
        public int v_CurrentPlayer = 0;

        public int v_Winner = -1;

        public string v_Joueur1 = "";
        public string v_Joueur2 = "";

        public int v_difficulty = -1;

        public puissance4()
        {
            // Initialiser les colonnes
            for (int col_index = 0; col_index < Grid.NUMBER_OF_COLS; col_index++)
            {
                v_NbPawnByRow.Add(0);
            }
        }

        public object Clone()
        {
            puissance4 v_Puissance4 = (puissance4)MemberwiseClone();
            v_Puissance4.grid = (Grid)grid.Clone();

            return v_Puissance4;
        }

        public string GetPlayerToPlay()
        {
            return v_CurrentPlayer == 0 ? v_Joueur1 : v_Joueur2;
        }

        public string GetWinnerName()
        {
            if (v_Winner == -1) { throw new Exception("Impossible de récupérer le nom du gagnant car il n'y a pas de gagnant"); }
            return v_Winner == 0 ? v_Joueur1 : v_Joueur2;
        }

        public List<int> GetAvailableCols()
        {
            List<int> cols = new List<int>();
            for (int row_index = 0; row_index < Grid.NUMBER_OF_ROWS; row_index ++)
            {
                if (v_NbPawnByRow[row_index] < Grid.NUMBER_OF_ROWS - 1)
                {
                    cols.Add(row_index);
                }
            }
            return cols;
        }

        public int PlacePawn(int col_index)
        {
            if (col_index < 0 || col_index >= Grid.NUMBER_OF_COLS)
            {
                throw new ArgumentException("Index de colonne invalide");
            }

            if (v_NbPawnByRow[col_index] - 1 >= Grid.NUMBER_OF_ROWS)
            {
                throw new ArgumentException("Plus de place dans la colonne choisie");
            }

            this.grid.Play(col_index, v_NbPawnByRow[col_index], this.v_CurrentPlayer);
            v_NbPawnByRow[col_index]++;

            // Vérifier s'il y a un gagnant
            if (grid.v_WinVectors.Count > 0 && v_Winner == -1)
            {
                this.v_Winner = v_CurrentPlayer;
            }
            this.v_CurrentPlayer = (this.v_CurrentPlayer + 1) % 2;

            return v_NbPawnByRow[col_index] - 1;
        }

        public bool CheckIfDraw()
        {
            int v_TotalPawn = v_NbPawnByRow.Sum(x => x);
            return v_TotalPawn >= Grid.NUMBER_OF_COLS * Grid.NUMBER_OF_ROWS;
        }
    }
}
