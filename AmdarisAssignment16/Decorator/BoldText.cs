namespace AmdarisAssignment16;

public class BoldText : TextDecorator
{
    public BoldText(ITextFormatter textFormatter) : base(textFormatter)
    {
    }

    public override string Format()
    {
        return "<b>" + _textFormatter.Format() + "</b>";
    }
}