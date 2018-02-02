namespace SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').Reverse().ToArray();

            Stack<string> elements = new Stack<string>(input);

            while (elements.Count > 1)
            {
                int leftOperand = int.Parse(elements.Pop());
                string operation = elements.Pop();
                int rightOperand = int.Parse(elements.Pop());

                switch (operation)
                {
                    case "+":
                        elements.Push((leftOperand + rightOperand).ToString());
                        break;
                    case "-":
                        elements.Push((leftOperand - rightOperand).ToString());
                        break;
                }
            }

            Console.WriteLine(elements.Pop());
        }
    }
}
