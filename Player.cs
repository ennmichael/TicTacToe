using System;

namespace XOX
{
    class Player
    {
        public Player()
        {
            Turn = FieldValue.OX;
        }

        public void Toggle()
        {
            if (Turn == FieldValue.X)
                Turn = FieldValue.OX;
            else
                Turn = FieldValue.X;
        }

        public FieldValue Turn
        {
            get;
            private set;
        }
    }
}

