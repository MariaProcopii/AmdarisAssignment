namespace AmdarisAssignment16;

public class UnderlineText : TextDecorator
{
    public UnderlineText(ITextFormatter textFormatter) : base(textFormatter)
    {
    }

    public override string Format()
    {
        return "<u>" + _textFormatter.Format() + "</u>";
    }
}