namespace COM3D2.Highheel.Plugin.UI
{
    public class NumberInputEventArgs : System.EventArgs
    {
        public readonly float Value;

        public NumberInputEventArgs(float value) => Value = value;
    }
}