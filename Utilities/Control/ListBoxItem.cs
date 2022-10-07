namespace Utilities.Control
{
    public class ListBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public ListBoxItem(string text, object value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
