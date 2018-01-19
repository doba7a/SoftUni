namespace EmployeeData
{
    using System;

    public class EmployeeData
    {
        public static void Main()
        {
            string firstName = Console.ReadLine();
            Console.WriteLine("First name: {0}", firstName);
            string lastName = Console.ReadLine();
            Console.WriteLine("Last name: {0}", lastName);
            byte age = byte.Parse(Console.ReadLine());
            Console.WriteLine("Age: {0}", age);
            char gender = char.Parse(Console.ReadLine());
            Console.WriteLine("Gender: {0}", gender);
            long personalID = long.Parse(Console.ReadLine());
            Console.WriteLine("Personal ID: {0}", personalID);
            int uniqueEmployeeNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Unique Employee number: {0}", uniqueEmployeeNumber);
        }
    }
}