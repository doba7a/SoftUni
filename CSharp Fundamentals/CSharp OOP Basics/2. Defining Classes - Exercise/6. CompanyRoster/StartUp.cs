using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        Employee[] employeesData = new Employee[numberOfInputs];

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string currentEmployeeName = inputData[0];
            decimal currentEmployeeSalary = decimal.Parse(inputData[1]);
            string currentEmployeePosition = inputData[2];
            string currentEmployeeDepartment = inputData[3];

            Employee currentEmployee = 
                new Employee(currentEmployeeName, currentEmployeeSalary, currentEmployeePosition, currentEmployeeDepartment);

            if (inputData.Length == 6)
            {
                string currentEmployeeEmail = inputData[4];
                int currentEmployeeAge = int.Parse(inputData[5]);

                currentEmployee.Email = currentEmployeeEmail;
                currentEmployee.Age = currentEmployeeAge;
            }
            else if (inputData.Length == 5)
            {
                if (inputData[4].Contains("@"))
                {
                    string currentEmployeeEmail = inputData[4];
                    currentEmployee.Email = currentEmployeeEmail;
                }
                else
                {
                    int currentEmployeeAge = int.Parse(inputData[4]);
                    currentEmployee.Age = currentEmployeeAge;
                }
            }

            employeesData[i] = currentEmployee;
        }

        var outputData = employeesData
                .GroupBy(e => e.Department)
                .Select(d => new
                {
                    Department = d.Key,
                    AverageSalary = d.Average(e => e.Salary),
                    Employees = d.OrderByDescending(emp => emp.Salary).ToArray()
                })
                .OrderByDescending(d => d.AverageSalary)
                .FirstOrDefault();

        if (outputData != null)
        {
            Console.WriteLine($"Highest Average Salary: {outputData.Department}");

            foreach (var employee in outputData.Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}

