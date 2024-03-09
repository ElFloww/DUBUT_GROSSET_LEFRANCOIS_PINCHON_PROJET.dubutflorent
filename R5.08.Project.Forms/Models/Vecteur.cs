namespace R5._08.Project.Forms.Models
{
    public class Vecteur : ICloneable
    {
        public int m_Lenght = 0;
        public List<int[]> m_Coo = new();// ex. { { 1, 2 }, { 2, 3 }, ... } : les coordonnées que traversent le vecteur (pour être efficace en temps d'execution)
        public string m_Direction;
        public string[] m_AllDirections = { "Verticale", "Horizontale", "Diagonale-Gauche", "Diagonale-Droite", "---" };

        public Vecteur(int p_Lenght, string p_Direction)
        {
            if (!m_AllDirections.Contains(p_Direction))
            {
                throw new ArgumentException(p_Direction + " Invalide; Choix possibles: " + m_AllDirections.ToString());
            }

            m_Lenght = p_Lenght;
            m_Direction = p_Direction;
        }

        public object Clone()
        {
            Vecteur v_Vector = (Vecteur)MemberwiseClone();
            v_Vector.m_Coo = new List<int[]>();

            foreach (int[] v_Coo in m_Coo)
            {
                v_Vector.AddCoo(v_Coo[0], v_Coo[1]);
            }
            return v_Vector;
        }

        public void AddCoo(int p_X, int p_Y)
        {
            int[] v_Tmp = new int[2];
            v_Tmp[0] = p_X;
            v_Tmp[1] = p_Y;
            m_Coo.Add(v_Tmp);
            m_Lenght = m_Coo.Count;
        }

        public void MergeCoo(List<int[]> p_Coo)
        {
            if (p_Coo is null) { return; }

            // Utilisation d'un HashSet pour éviter les duplications
            HashSet<int[]> v_MergedSet = new(new IntArrayEqualityComparator());
            if (m_Coo is null)
            {
                m_Coo = new List<int[]>(p_Coo);
            }
            // Merger les éléments des listes
            foreach (int[] v_Array in m_Coo)
            {
                v_MergedSet.Add(v_Array);
            }
            foreach (int[] v_Array in p_Coo)
            {
                v_MergedSet.Add(v_Array);
            }

            m_Coo = new List<int[]>(v_MergedSet);
        }
    }
}