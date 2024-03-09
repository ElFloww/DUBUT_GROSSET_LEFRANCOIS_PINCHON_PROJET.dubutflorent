namespace ProjetForm
{
    public class Puissance4
    {
        private bool m_RedPlayerToPlay;

        public int m_Difficulty;
        private bool[,] m_Board;
        private bool[,] m_RedPawnOnBoard;
        private bool[,] m_YellowPawnOnBoard;

        public void SetRedPlayerToPlay(bool p_RedPlayerToPlay)
        {
            m_RedPlayerToPlay = p_RedPlayerToPlay;
        }

        public bool IsRedPlayerToPlay()
        {
            return m_RedPlayerToPlay;
        }

        public void setOnBoard(int p_X, int p_Y, bool p_IsOnBoard)
        {
            m_Board[p_X, p_Y] = p_IsOnBoard;
        }

        public bool[,] GetBoard()
        {
            return m_Board;
        }

        public void setRedPawnOnBoard(int p_X, int p_Y, bool p_IsOnBoard)
        {
            m_RedPawnOnBoard[p_X, p_Y] = p_IsOnBoard;
        }

        public bool[,] getRedPawnOnBoard()
        {
            return m_RedPawnOnBoard;
        }

        public void setYellowPawnOnBoard(int p_X, int p_Y, bool p_IsOnBoard)
        {
            m_YellowPawnOnBoard[p_X, p_Y] = p_IsOnBoard;
        }

        public bool[,] getYellowPawnOnBoard()
        {
            return m_YellowPawnOnBoard;
        }
    }
}