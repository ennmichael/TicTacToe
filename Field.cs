using System.Collections.Generic;
using System;
using Gtk;

namespace XOX
{
    enum FieldValue
    {
        None = 0, X = 1, OX = 2
    }

    static class FieldTags
    {
        static FieldTags()
        {
            dct.Add(FieldValue.None, "-");
            dct.Add(FieldValue.X, "X");
            dct.Add(FieldValue.OX, "O");
        }

        static public Label GetTagLabel(FieldValue fv)
        {
            var result = new Label();
            result.Markup = GetTag(fv);

            return result;
        }

        static public string GetTag(FieldValue fv)
        {
            return dct[fv];
        }

        static private readonly Dictionary<FieldValue, string> dct = new Dictionary<FieldValue, string>();
    }
}
