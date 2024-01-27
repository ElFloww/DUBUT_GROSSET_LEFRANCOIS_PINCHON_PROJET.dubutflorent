using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace R5._08.Project.Forms.Models
{
    public class Tile
    {
        public List<Vecteur> v_Vectors = new List<Vecteur>();
        public List<Vecteur> v_WinVector = new List<Vecteur>();

        public int v_Player; // 0 -> Rouge | 1 -> Jaune | -1 -> personne
        public int x;
        public int y;
        public int v_GridId;

        public Tile(int p_Player, int x, int y, int v_GridId)
        {
            this.v_Player = p_Player;
            this.x = x;
            this.y = y;

            //List<Tile> v_Neighbors = this.GetNeighbors();
            //foreach (Tile v_Neighbor in v_Neighbors)
            //{
            //    v_Neighbor.NewNeighbor(this);
            //}

            this.v_GridId = v_GridId;
        }

        /** Permet de mettre à jour un voisin de la Tile **/
        public void NewNeighbor(Tile p_tile)
        {
            if (p_tile.v_Player != v_Player || p_tile.v_Player == 0 || v_Player == 0) { return; }
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

        /** Mettre à jour la taille des vecteurs de la Tile **/
        /** Mal fini ???? **/
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

            // Mettre à jour les vecteurs verticales
            if (v_Vertical.Count > 0)
            {
                Vecteur v_RootVector = v_Vertical[0];
                v_Vertical.RemoveAt(0);

                foreach (Vecteur v_Vector in v_Vertical) {
                    v_RootVector.v_Lenght += v_Vector.v_Lenght - 1;
                    v_RootVector.MergeCoo(v_Vector.v_Coo);

                    foreach (int[] v_Coo in v_RootVector.v_Coo)
                    {
                        Tile v_OtherTile = Grid.ALL_GRIDS[v_GridId].v_GridTiles[(v_Coo[0], v_Coo[1])];
                        v_OtherTile.v_Vectors.Remove(v_Vector);
                        v_OtherTile.v_Vectors.Add(v_RootVector);
                    }
                }
            }
        }

        /** Récupérer les voisins de la Tile **/
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

                if (Grid.ALL_GRIDS[v_GridId].v_GridTiles.TryGetValue((v_NeighborX, v_NeighborY), out var v_NeighborTile))
                {
                    v_Neighbors.Add(v_NeighborTile);
                }
            }

            return v_Neighbors;
        }
    }
}
