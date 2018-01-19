namespace X
{
    using System;

    public class X
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n / 2; i++)
            {
                Console.Write(new string(' ', i));
                Console.Write('x');
                Console.Write(new string(' ', n - 2 - (i * 2)));
                Console.Write('x');
                Console.WriteLine(new string(' ', i));
            }

            Console.Write(new string(' ', n / 2));
            Console.Write('x');
            Console.WriteLine(new string(' ', n / 2));

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Console.Write(new string(' ', i));
                Console.Write('x');
                Console.Write(new string(' ', n - 2 - (i * 2)));
                Console.Write('x');
                Console.WriteLine(new string(' ', i));
            }
        }
    }
}