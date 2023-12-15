using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R5._08.Project.Forms.Models
{
    internal class IntArrayEqualityComparator : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            // Comparaison des tableaux élément par élément
            return x.SequenceEqual(y);
        }

        public int GetHashCode(int[] obj)
        {
            // Génération d'un code de hachage basé sur les éléments du tableau
            int hash = 17;
            foreach (var value in obj)
            {
                hash = hash * 23 + value.GetHashCode();
            }
            return hash;
        }
    }
}
