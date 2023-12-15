using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace R5._08.Project.Forms.Models
{
    public class Grid
    {
        public Dictionary<(int x, int y), Tile> v_GridTiles = new Dictionary<(int x, int y), Tile>();


        public Tile Get(int x, int y)
        {
            return v_GridTiles[(x, y)];
        }

        public void Add(Tile v_Tile)
        {
            v_GridTiles.Add((v_Tile.x, v_Tile.y), v_Tile);
        }
        
    }
    public class Tile
    {
        public static Dictionary<int, Grid> ALL_TILES = new Dictionary<int, Grid>();
        // { IdGrid: {(x,y): Tile, ...}, ...}

        public List<Vecteur> v_Vectors = new List<Vecteur>();
        public List<Vecteur> v_WinVector = new List<Vecteur>();

        public int v_Player; // 0 -> Rouge | 1 -> Jaune
        public int x;
        public int y;
        public int v_GridId;

        public Tile(int p_Player, int x, int y, int v_GridId)
        {
            this.v_Player = p_Player;
            this.x = x;
            this.y = y;

            if (!Tile.ALL_TILES.ContainsKey(v_GridId))
            {
                Tile.ALL_TILES.Add(v_GridId, new Grid());
            }
            Tile.ALL_TILES[v_GridId].Add(this);

            List<Tile> v_Neighbors = this.GetNeighbors();
            foreach (Tile v_Neighbor in v_Neighbors)
            {
                v_Neighbor.NewNeighbor(this);
            }

            this.v_GridId = v_GridId;
        }

        public void NewNeighbor(Tile p_tile)
        {
            int v_XDirection = p_tile.x - this.x; // -1: à gauche  | 0: même niveau | 1: à droite
            int v_YDirection = p_tile.y - this.y; // -1: au dessus | 0: même niveau | 1: en dessous

            string v_Direction;

            // { "Vertical", "Horizontale", "Diagonale-Gauche", "Diagonale-Droite" }
            if (v_XDirection == -1 && v_YDirection == -1 || v_XDirection == 1 && v_YDirection == 1)
            {
                v_Direction = "Diagonale-Gauche";

            } else if (v_XDirection == -1 && v_YDirection == 0 || v_XDirection == 1 && v_YDirection == 0)
            {
                v_Direction = "Horizontale";

            } else if (v_XDirection == -1 && v_XDirection == 1 || v_XDirection == 1 && v_XDirection == -1)
            {
                v_Direction = "Diagonale-Droite";

            } else if (v_XDirection == 0 && v_YDirection == -1 || v_XDirection == 0 && v_YDirection == 1)
            {
                v_Direction = "Vertical";

            } else { return; }


            // Metre à jour les vecteurs existants
            foreach (Vecteur vector in this.v_Vectors)
            {
                if (vector.v_Direction == v_Direction)
                {
                    vector.v_Lenght += 1;
                    p_tile.v_Vectors.Add(vector);

                    if (vector.v_Lenght >= 4)
                    {
                        this.v_WinVector.Add(vector);
                    }
                }
            }

            Vecteur v_NewVector = new(2, v_Direction);

            p_tile.v_Vectors.Add(v_NewVector);
            this.v_Vectors.Add(v_NewVector);
        }

        public void UpdateVectors()
        {
            // { "Vertical", "Horizontale", "Diagonale-Gauche", "Diagonale-Droite" }

            List<Vecteur> v_Vertical = new List<Vecteur>();
            List<Vecteur> v_Horizontal = new List<Vecteur>();
            List<Vecteur> v_DiagonaleGauche = new List<Vecteur>();
            List<Vecteur> v_DiagonaleDroite = new List<Vecteur>();

            foreach (Vecteur v_Vector in this.v_Vectors)
            {
                if (v_Vector.v_Direction == "Vertical") { v_Vertical.Add(v_Vector); }
                else if (v_Vector.v_Direction == "Horizontal") { v_Horizontal.Add(v_Vector); }
                else if (v_Vector.v_Direction == "Diagonale-Gauche") { v_DiagonaleGauche.Add(v_Vector); }
                else if (v_Vector.v_Direction == "Diagonale-Droite") { v_DiagonaleDroite.Add(v_Vector); }
                else { throw  new Exception("Direction de vecteur invalide: " +  v_Vector.v_Direction); }
            }

            if (v_Vertical.Count > 0)
            {
                Vecteur v_RootVector = v_Vertical[0];
                v_Vertical.RemoveAt(0);

                foreach (Vecteur v_Vector in v_Vertical) {
                    v_RootVector.v_Lenght += v_Vector.v_Lenght - 1;
                    v_RootVector.MergeCoo(v_Vector.v_Coo);

                    foreach (int[] v_Coo in v_RootVector.v_Coo)
                    {
                        Tile v_OtherTile = Tile.ALL_TILES[(v_Coo[0], v_Coo[1])];
                        v_OtherTile.v_Vectors.Remove(v_Vector);
                        v_OtherTile.v_Vectors.Add(v_RootVector);
                    }
                }
            }
        }

        public List<Tile> GetNeighbors()
        {
            List<Tile> v_Neighbors = new List<Tile>();

            // Déplacements dans les axes x et y inclus dans les tableaux
            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            // Vérifiez chaque voisin potentiel
            for (int i = 0; i < 8; i++)
            {
                int v_NeighborX = this.x + dx[i];
                int v_NeighborY = this.y + dy[i];

                if (ALL_TILES.TryGetValue((v_NeighborX, v_NeighborY), out var v_NeighborTile))
                {
                    v_Neighbors.Add(v_NeighborTile);
                }
            }

            return v_Neighbors;
        }
    }
}
