using System;

public class Company
{
    private string name;
    private string department;
    private double salary;

    public Company(string nameGiven, string departmentGiven, double salaryGiven)
    {
        this.Name = nameGiven;
        this.Department = departmentGiven;
        this.Salary = salaryGiven;
    }

    public string Name { get => name; set => name = value; }
    public string Department { get => department; set => department = value; }
    public double Salary { get => salary; set => salary = value; }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary:F2}{Environment.NewLine}";
    }
}

