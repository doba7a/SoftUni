namespace Exercise.Core.Models
{
    using Exercise.Models;
    using System.Collections.Generic;

    public class ManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Employee> EmployeesManaged { get; set; }

        public int EmployeesManagedCount { get; set; }
    }
}
