namespace AmdarisAssignment16;

public abstract class TextDecorator : ITextFormatter
{
    protected ITextFormatter _textFormatter;
    public TextDecorator(ITextFormatter textFormatter)
    {
        _textFormatter = textFormatter;
    }

    public abstract string Format();
    
    public ITextFormatter Remove(ITextFormatter removeDecorator)
    {
        if (GetType() == removeDecorator.GetType())
        {
            return _textFormatter;
        }

        return _textFormatter is TextDecorator decorator ? decorator.Remove(removeDecorator) : this;
    }
}