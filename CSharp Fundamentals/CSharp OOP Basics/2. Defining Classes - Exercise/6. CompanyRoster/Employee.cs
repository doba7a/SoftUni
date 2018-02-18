﻿class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = "n/a";
        this.age = -1;
    }

    public string Name { get => name; set => name = value; }
    public decimal Salary { get => salary; set => salary = value; }
    public string Position { get => position; set => position = value; }
    public string Department { get => department; set => department = value; }
    public string Email { get => email; set => email = value; }
    public int Age { get => age; set => age = value; }
}
