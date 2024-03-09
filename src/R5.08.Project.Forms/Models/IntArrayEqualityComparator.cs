namespace R5._08.Project.Forms.Models
{
    internal class IntArrayEqualityComparator : IEqualityComparer<int[]>
    {
        public bool Equals(int[] p_X, int[] p_Y)
        {
            // Comparaison des tableaux élément par élément
            return p_X.SequenceEqual(p_Y);
        }

        public int GetHashCode(int[] p_Obj)
        {
            // Génération d'un code de hachage basé sur les éléments du tableau
            int v_Hash = 17;
            foreach (int v_Value in p_Obj)
            {
                v_Hash = v_Hash * 23 + v_Value.GetHashCode();
            }
            return v_Hash;
        }
    }
}