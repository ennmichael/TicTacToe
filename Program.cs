using System;
using Gtk;

namespace XOX
{
	class MainClass
	{
        public static void Main(string[] args)
        {
            Application.Init();

            var win = new XOXWindow();
            int theLen = 3;

            if (args.Length == 1)
            {
                if (!Int32.TryParse(args[0], out theLen))
                {
                    win.ShowMessage("Command-line size parameter isn't a number!");
                    return;
                }

                if (theLen > 25)
                {
                    win.ShowMessage("Command-line size parameter too big!");
                    return;
                }

                if (theLen < 3)
                {
                    win.ShowMessage("Command-line size parameter too small!");
                    return;
                }
            }
            else if (args.Length != 0)
            {
                win.ShowMessage("Incorrect number of command-line parameters!");
                return;
            }

            var player = new Player();
            var table = new Table(player, theLen);
            table.PackTo(win);
            win.ShowAll();

            Application.Run();
        }
	}
}
