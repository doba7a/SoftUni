namespace DebitCardNumber
{
    using System;

    public class DebitCardNumber
    {
        public static void Main()
        {
            var firstFourNumbers = int.Parse(Console.ReadLine());
            var secondFourNumbers = int.Parse(Console.ReadLine());
            var thirdFourNumbers = int.Parse(Console.ReadLine());
            var fourthFourNumbers = int.Parse(Console.ReadLine());

            Console.WriteLine($"{firstFourNumbers:D4} {secondFourNumbers:D4} {thirdFourNumbers:D4} {fourthFourNumbers:D4}");
        }
    }
}