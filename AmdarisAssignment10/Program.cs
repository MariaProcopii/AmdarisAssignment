namespace AmdarisAssignment10;

class Program
{
    static void Main(string[] args)
    {
        var toAddress = GetEmailAddress();
        EmailSender.SendEmail(toAddress);
    }

    private static string GetEmailAddress()
    {
        Console.WriteLine("Provide email address to confirm your subscription:");
        return Console.ReadLine();
    }
}
