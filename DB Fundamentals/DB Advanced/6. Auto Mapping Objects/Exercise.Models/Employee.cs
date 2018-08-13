namespace Exercise.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee(string firstName, string lastName, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.EmployeesManaged = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public Employee Manager { get; set; }

        public ICollection<Employee> EmployeesManaged { get; set; }
    }
}
