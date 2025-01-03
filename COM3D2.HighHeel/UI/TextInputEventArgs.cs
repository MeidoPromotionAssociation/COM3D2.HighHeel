namespace COM3D2.Highheel.Plugin.UI
{
    public class TextInputEventArgs : System.EventArgs
    {
        public readonly string Text;

        public TextInputEventArgs(string text) => Text = text;
    }
}