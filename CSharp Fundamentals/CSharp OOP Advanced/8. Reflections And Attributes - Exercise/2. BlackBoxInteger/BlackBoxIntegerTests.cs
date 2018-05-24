using System;
using System.Reflection;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        string input = Console.ReadLine();

        Type classType = Type.GetType("BlackBoxInteger");
        FieldInfo result = classType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
        BlackBoxInteger blackBox = (BlackBoxInteger)Activator.CreateInstance(classType, true);

        while (input != "END")
        {
            string[] inputData = input.Split('_');
            string methodName = inputData[0];
            int value = int.Parse(inputData[1]);

            MethodInfo currentMethod = classType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            currentMethod.Invoke(blackBox, new object[] { value });

            Console.WriteLine(result.GetValue(blackBox));

            input = Console.ReadLine();
        }
    }
}

