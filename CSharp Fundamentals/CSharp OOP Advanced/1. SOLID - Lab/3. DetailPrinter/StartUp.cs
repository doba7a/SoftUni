using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        Employee employee = new Employee("gosho");
        Manager manager = new Manager("pesho", new List<string>() { "first document", "second document" });
        GeneralManager gm = new GeneralManager("prakash", new List<string>() { manager.Name });

        List<Employee> employees = new List<Employee>() { employee, manager, gm };

        DetailsPrinter dp = new DetailsPrinter(employees);

        dp.PrintDetails();
    }
}

