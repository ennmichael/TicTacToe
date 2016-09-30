using System.Threading;
using System;
using Gtk;

namespace XOX
{
    class XOXButton : Button
    {
        public FieldValue Value
        {
            get;
            private set;
        }
            
        public XOXButton(Table newTbl, Player newP)
            : base(FieldTags.GetTag(FieldValue.None))
        {
            FocusOnClick = false;

            tbl = newTbl;
            p = newP;

            Resize();
        }

        protected override void OnPressed()
        {
            if (Value != FieldValue.None || tbl.Winner != FieldValue.None) return;

            tbl.NotifyChange();

            Value = p.Turn;
            p.Toggle();

            Label = FieldTags.GetTag(Value);
            FieldValue winner = tbl.Winner;

            if (winner != FieldValue.None)
            {
                ((XOXWindow)Toplevel).ShowMessage(FieldTags.GetTag(winner) + " wins!");
            }
            else if (tbl.Filled())
            {
                ((XOXWindow)Toplevel).ShowMessage("Tie!");
            }

            Resize();
        }

        private void Resize()
        {
            WidthRequest = 60;
            HeightRequest = 60;
        }

        private readonly Table tbl;
        private readonly Player p;
    }
}

