namespace AmdarisAssignment5;
using System.Text;

public class StringManipulator
{
    public static void DisplayWordCount(string textSample)
    {
        var wordCount = textSample.Split(" ");
        Console.WriteLine(wordCount.Length);
    }

    public static void DisplaySentenceCount(string textSample)
    {
        var sentenceCount = textSample.Split(".");
        Console.WriteLine(sentenceCount.Length);
    }

    public static void DisplayOcurrenceCount(string textSample, string wordToCount)
    {
        var count = 0;
        var wordCount = textSample.Split(" ");
        foreach (var str in wordCount)
        {
            if (str.Equals(wordToCount, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    public static void ReverseString(string stringSample)
    {
        var stringBuilder = new StringBuilder();
        for (var i = stringSample.Length - 1; i >= 0; i--)
        {
            stringBuilder.Append(stringSample[i]);
        }
        
        Console.WriteLine(stringBuilder.ToString());
    }

    public static void ReplaceOcurrence(string originalString, string oldValue, string newValue)
    {
        var newString = originalString.Replace(oldValue, newValue);
        Console.WriteLine(newString);
    }
}
