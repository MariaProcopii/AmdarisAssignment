namespace AmdarisAssignment16;

public class ItalicText : TextDecorator
{
    public ItalicText(ITextFormatter textFormatter) : base(textFormatter)
    {
    }

    public override string Format()
    {
        return "<i>" + _textFormatter.Format() + "</i>";
    }
}