using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        PrimitiveCalculator calculator = new PrimitiveCalculator();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputData = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (inputData[0] == "mode")
            {
                char strategy = inputData[1][0];

                calculator.ChangeStrategy(strategy);
            }
            else
            {
                int[] operands = inputData.Select(int.Parse).ToArray();
                int result = calculator.PerformCalculation(operands[0], operands[1]);
                Console.WriteLine(result);

            }

            input = Console.ReadLine();
        }
    }
}


