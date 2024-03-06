using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R5._08.Project.Forms.Models
{
    public class Grid : ICloneable
    {
        public const int NUMBER_OF_ROWS = 6;
        public const int NUMBER_OF_COLS = 7;

        public static Dictionary<int, Grid> m_AllGrids = new Dictionary<int, Grid>();
        // { IdGrid: {(x,y): Tile, ...}, ...}

        public Dictionary<(int x, int y), Tile> m_GridTiles = new Dictionary<(int x, int y), Tile>();

        public int m_GridId;

        public List<Vecteur> m_WinVectors = new();

        public Grid()
        {
            m_GridId = m_AllGrids.Count;
            m_AllGrids.Add(m_GridId, this);

            // Init la grid
            for (int v_RowIndex = 0; v_RowIndex < NUMBER_OF_ROWS; v_RowIndex++)
            {
                for (int v_ColIndex = 0; v_ColIndex < NUMBER_OF_COLS; v_ColIndex++)
                {
                    AddTile(v_ColIndex, v_RowIndex);
                }
            }
        }

        public object Clone()
        {
            Grid v_Grid = (Grid)MemberwiseClone();

            v_Grid.m_GridTiles = new Dictionary<(int x, int y), Tile>();
            v_Grid.m_WinVectors = new List<Vecteur>();
            foreach ((int, int) v_Coo in m_GridTiles.Keys)
            {
                v_Grid.m_GridTiles[v_Coo] = (Tile)m_GridTiles[v_Coo].Clone();
            }
            v_Grid.m_GridId = -1;
            m_AllGrids.Add(-1, v_Grid);

            return v_Grid;
        }

        public Tile Get(int p_X, int p_Y)
        {
            return m_GridTiles[(p_X, p_Y)];
        }

        public void Play(int p_X, int p_Y, int p_Player)
        {
            Tile v_Tile = Get(p_X, p_Y);
            v_Tile.UpdateTilePlayer(p_Player);

            if (v_Tile.m_WinVectors.Count > 0)
            {
                m_WinVectors.AddRange(v_Tile.m_WinVectors);
            }
            Console.WriteLine(m_WinVectors.Count);
        }

        public void AddTile(int p_X, int p_Y)
        {
            Tile v_Tile = new(-1, p_X, p_Y, m_GridId);
            if (!m_GridTiles.ContainsKey((p_X, p_Y)))
            {
                m_GridTiles.Add((p_X, p_Y), v_Tile);
            }
        }

        public string PrintString()
        {
            string v_Grids = "";
            for (int v_Y = NUMBER_OF_ROWS - 1; v_Y >= 0; v_Y--)
            {
                for (int v_X = 0; v_X < NUMBER_OF_COLS; v_X++)
                {
                    Tile v_Tile = m_GridTiles[(v_X, v_Y)];
                    v_Grids += "[" + v_Tile.m_Player.ToString() + "]";
                }
                v_Grids += "\n";
            }

            return v_Grids;
        }
    }
}