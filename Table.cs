﻿using System.Collections.Generic;
using System;
using Gtk;

namespace XOX
{
    class Point
    {
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public Point()
        {
        }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Set(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    class Table
    {
        private FieldValue winnerBack = FieldValue.None;
        private bool winnerCalculated = false;

        private readonly XOXButton [,] buttons;
        private readonly int len;
        private readonly Player p;

        public FieldValue Winner
        {
            get
            {
                CalculateWinnerBackIfNeeded();
                return winnerBack;
            }
        }

        public Table(Player p, int len)
        {
            buttons = new XOXButton[len, len];
            this.len = len;
            this.p = p;

            for (int x = 0; x < this.len; ++ x)
                for (int y = 0; y < this.len; ++ y)
                    buttons[x,y] = new XOXButton(this, p);
        }

        public void NotifyChange()
        {
            winnerCalculated = false;
        }

        public bool Filled()
        {
            return p.TurnCount >= len * len - 1;
        }

        public void PackTo(XOXWindow w)
        {
            w.Add(GetVBox());
        }

        private void CalculateWinnerBackIfNeeded()
        {
            if (p.TurnCount < 4)
                return;

            if (!winnerCalculated)
            {
                Console.WriteLine("Calculating for" + p.Turn.ToString());

                winnerCalculated = true;

                var start = new Point(); // So I don't have to destroy and create a variable within every loop
                var dir = new Point();

                System.Action specifiedCheck = // Not to be confused with Gtk.Action
                () =>
                {
                        CheckSingle(start, dir, p.Turn, ref winnerBack);
                };

                dir.Set(1, 0);
                start.X = 0;

                for (start.Y = 0; start.Y < len; ++start.Y)
                    specifiedCheck();

                dir.Set(0, 1);
                start.Y = 0;

                for (start.X = 0; start.X < len; ++start.X)
                    specifiedCheck();

                dir.Set(1, 1);
                start.Set(0, 0);
                specifiedCheck();

                dir.Set(1, -1);
                start.Set(0, len - 1);
                specifiedCheck();
            }
        }

        private void CheckSingle(
            Point start, 
            Point direction, 
            FieldValue fieldToLookFor, 
            ref FieldValue result)
        {
            if (result != FieldValue.None) return;
            result = fieldToLookFor;

            for (int i = 0; i < len; ++i)
                if (buttons[start.X + direction.X * i, start.Y + direction.Y * i].Value != fieldToLookFor)
                {
                    result = FieldValue.None;
                    return;
                }
        }

        private HBox GetHBox(int row)
        {
            var result = new HBox();

            for (int column = 0; column < len; ++column)
                result.PackStart(buttons[column, row]);

            return result;
        }

        private VBox GetVBox()
        {
            var result = new VBox();

            for (int i = 0; i < len; ++i)
                result.PackStart(GetHBox(i));

            return result;
        }
    }
}

