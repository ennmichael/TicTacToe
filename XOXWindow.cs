using System;
using Gtk;

namespace XOX
{
    class XOXWindow : Window
    {
        public XOXWindow()
            : base("")
        {
            SetDefaultSize(180, 180);

            DeleteEvent += (sender, args) =>
            {
                Application.Quit();
            };
        }

        public void ShowMessage(string text)
        {
            var md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Info,
                ButtonsType.Close, text);
            md.Run();
            md.Destroy();
        }
    }
}

