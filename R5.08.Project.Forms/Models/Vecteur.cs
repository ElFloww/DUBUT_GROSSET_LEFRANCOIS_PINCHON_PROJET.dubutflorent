using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R5._08.Project.Forms.Models
{
    public class Vecteur: ICloneable
    {
        public int v_Lenght = 0;
        public List<int[]> v_Coo;// ex. { { 1, 2 }, { 2, 3 }, ... } : les coordonnées que traversent le vecteur (pour être efficace en temps d'execution)
        public string v_Direction;
        public string[] v_AllDirections = { "Verticale", "Horizontale", "Diagonale-Gauche", "Diagonale-Droite", "---" };

        public Vecteur(int p_Lenght, string p_Direction) {
            if (!v_AllDirections.Contains(p_Direction)) {
                throw new ArgumentException(p_Direction + " Invalide; Choix possibles: " + v_AllDirections.ToString());
            }

            this.v_Lenght = p_Lenght;
            this.v_Direction = p_Direction;
        }

        public object Clone()
        {
            Vecteur vector = (Vecteur)MemberwiseClone();
            vector.v_Coo = new List<int[]>();

            foreach (int[] coo in v_Coo)
            {
                vector.AddCoo(coo[0], coo[1]);
            }
            return vector;
        }

        public void AddCoo(int x, int y)
        {
            int[] tmp = new int[2];
            tmp[0] = x;
            tmp[1] = y;
            this.v_Coo.Add(tmp);
            this.v_Lenght = this.v_Coo.Count;
        }

        public void MergeCoo(List<int[]> p_Coo) {
            if (p_Coo == null) { return; }

            // Utilisation d'un HashSet pour éviter les duplications
            HashSet<int[]> v_MergedSet = new HashSet<int[]>(new IntArrayEqualityComparator());
            if (this.v_Coo == null)
            {
                this.v_Coo = new List<int[]>(p_Coo);
            }
            // Merger les éléments des listes
            foreach (var v_Array in this.v_Coo)
            {
                v_MergedSet.Add(v_Array);
            }
            foreach (var v_Array in p_Coo)
            {
                v_MergedSet.Add(v_Array);
            }

            this.v_Coo = new List<int[]>(v_MergedSet);
        }
    }
}
