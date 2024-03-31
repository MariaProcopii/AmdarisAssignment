namespace AmdarisAssignment16;


class Program
{
    static void Main()
    {
        var initText = new PlainText("Hello");
        var colorYellow = new ColorText(initText, ConsoleColor.Yellow);
        var italicText = new ItalicText(colorYellow);
        var colorGreen= new ColorText(italicText, ConsoleColor.Green);
        var boldText = new BoldText(colorGreen);
        var underlineText = new UnderlineText(boldText);
        
        Console.WriteLine(underlineText.Format());
        
        var undoOneDecorator = underlineText.Remove(underlineText);
        
        Console.WriteLine(undoOneDecorator.Format());
    }
}