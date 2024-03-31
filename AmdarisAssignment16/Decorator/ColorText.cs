namespace AmdarisAssignment16;

public class ColorText : TextDecorator
{
    private static Stack<ConsoleColor> _colors = new();

    public ColorText(ITextFormatter textFormatter, ConsoleColor color) : base(textFormatter)
    {
        _colors.Push(color);
    }

    public override string Format()
    {
        Console.ForegroundColor = _colors.Peek();
        return _textFormatter.Format();
    }
}