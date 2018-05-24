using System;

public class StartUp
{
    private static Smartphone smartphone = new Smartphone();

    public static void Main()
    {
        string[] phoneNumbers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.None);

        string[] sitesToVisit = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.None);

        foreach (string number in phoneNumbers)
        {
            if (smartphone.ValidNumber(number))
            {
                Console.WriteLine(smartphone.CallingNumber(number));
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        foreach (string url in sitesToVisit)
        {
            if (smartphone.ValidUrl(url))
            {
                Console.WriteLine(smartphone.VisitingSite(url));
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }
}