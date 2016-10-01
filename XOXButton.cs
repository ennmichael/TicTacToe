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
            if (Value != FieldValue.None)
                return;
            if (p.TurnCount < 3 && tbl.Winner != FieldValue.None)
                return;

            Console.WriteLine("---");
            tbl.NotifyChange();

            Value = p.Turn;

            Label = FieldTags.GetTag(Value);

            if (tbl.Winner != FieldValue.None)
            {
                ((XOXWindow)Toplevel).ShowMessage(FieldTags.GetTag(tbl.Winner) + " wins!");
            }
            else if (tbl.Filled())
            {
                ((XOXWindow)Toplevel).ShowMessage("Tie!");
            }
            
            p.Toggle();
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

