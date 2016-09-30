using System;

namespace XOX
{
    class Player
    {
        public FieldValue Turn
        {
            get;
            private set;
        }

        public uint TurnCount
        {
            get;
            private set;
        }

        public Player()
        {
            Turn = FieldValue.OX;
        }

        public void Toggle()
        {
            TurnCount += 1;

            if (Turn == FieldValue.X)
                Turn = FieldValue.OX;
            else
                Turn = FieldValue.X;
        }
    }
}

