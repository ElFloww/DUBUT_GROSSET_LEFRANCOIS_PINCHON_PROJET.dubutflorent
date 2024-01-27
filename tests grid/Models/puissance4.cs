using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R5._08.Project.Forms.Models
{
    internal class puissance4
    {
        private Grid grid = new Grid();

        public List<int> v_NbPawnByRow = new List<int>();

        public puissance4()
        {

            // Initialiser les colonnes
            for (int row_index = 0; row_index < Grid.NUMBER_OF_ROWS; row_index++)
            {
                v_NbPawnByRow.Add(0);
            }
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

        public void PlacePawn(int col_index)
        {
            if (col_index < 0 || col_index >= Grid.NUMBER_OF_COLS)
            {
                throw new ArgumentException("Index de colonne invalide");
            }

            if (v_NbPawnByRow[col_index] - 1 >= Grid.NUMBER_OF_ROWS)
            {
                throw new ArgumentException("Plus de place dans la colonne choisie");
            }

            v_NbPawnByRow[col_index]++;
            this.grid.
        }
    }
}
