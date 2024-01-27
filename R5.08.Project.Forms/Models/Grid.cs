using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R5._08.Project.Forms.Models
{
    public class Grid
    {
        public static Dictionary<int, Grid> ALL_GRIDS = new Dictionary<int, Grid>();
        // { IdGrid: {(x,y): Tile, ...}, ...}

        public static int NUMBER_OF_ROWS = 6;
        public static int NUMBER_OF_COLS = 7;

        public Dictionary<(int x, int y), Tile> v_GridTiles = new Dictionary<(int x, int y), Tile>();

        public int c_GridId;

        public Grid()
        {
            this.c_GridId = Grid.ALL_GRIDS.Count;
            Grid.ALL_GRIDS.Add(this.c_GridId, this);

            // Init la grid
            for (int row_index = 0; row_index <  NUMBER_OF_ROWS; row_index++)
            {
                for (int col_index = 0; col_index < NUMBER_OF_COLS; col_index++)
                {
                    AddTile(col_index, row_index);
                }
            }
        }

        public Tile Get(int x, int y)
        {
            return v_GridTiles[(x, y)];
        }

        public void Add(Tile v_Tile)
        {
            v_GridTiles.Add((v_Tile.x, v_Tile.y), v_Tile);
        }

        public void AddTile(int x, int y)
        {
            Tile tile = new Tile(-1, x, y, c_GridId);
            if (!this.v_GridTiles.ContainsKey((x, y)))
            {
                this.v_GridTiles.Add((x, y), tile);
            }
        }

    }
}
