namespace AmdarisAssignment16;

public class PlainText : ITextFormatter
{ 
    public string Text { get; set; }

    public PlainText(string text)
    {
        Text = text;
    }
    public string Format()
    {
        return Text;
    }

    public ITextFormatter GetChild()
    {
        return null;
    }
}