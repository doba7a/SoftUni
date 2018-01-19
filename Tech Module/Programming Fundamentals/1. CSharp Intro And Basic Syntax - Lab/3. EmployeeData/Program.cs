namespace EmployeeData
{
    using System;

    public class EmployeeData
    {
        public static void Main()
        {
            string employeeName = Console.ReadLine();
            Console.WriteLine($"Name: {employeeName}");

            int employeeAge = int.Parse(Console.ReadLine());
            Console.WriteLine($"Age: {employeeAge}");

            int employeeID = int.Parse(Console.ReadLine());
            Console.WriteLine($"Employee ID: {employeeID:D8}");

            decimal employeeSalary = decimal.Parse(Console.ReadLine());
            Console.WriteLine($"Salary: {employeeSalary:F2}");
        }
    }
}