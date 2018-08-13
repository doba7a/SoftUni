namespace Exercise.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Exercise.Data;
    using Exercise.IO;
    using Exercise.Models;
    using Exercise.Services.Contracts;
    using System;
    using System.Linq;

    public class EmployeeService : IEmployeeService
    {
        private readonly ExerciseContext context;
        private readonly IMapper mapper;

        public EmployeeService(ExerciseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public TModel AddEmployee<TModel>(string firstName, string lastName, decimal salary)
        {
            Employee employee = new Employee(firstName, lastName, salary);

            context.Employees.Add(employee);

            context.SaveChanges();

            TModel employeeDto = mapper.Map<TModel>(employee);

            return employeeDto;
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(string.Format(Constants.EmployeeNotFound, employeeId));
            }

            context.Employees.Remove(employee);

            context.SaveChanges();
        }

        public TModel EmployeeInfo<TModel>(int employeeId)
        {
            TModel employeeDto = context.Employees
                .Where(u => u.Id == employeeId)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .SingleOrDefault();

            if (employeeDto == null)
            {
                throw new ArgumentException(string.Format(Constants.EmployeeNotFound, employeeId));
            }

            return employeeDto;
        }

        public TModel EmployeePersonalInfo<TModel>(int employeeId)
        {
            TModel employeeDto = context.Employees
                .Where(u => u.Id == employeeId)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .SingleOrDefault();

            if (employeeDto == null)
            {
                throw new ArgumentException(string.Format(Constants.EmployeeNotFound, employeeId));
            }

            return employeeDto;
        }

        public TModel SetAddress<TModel>(int employeeId, string address)
        {
            Employee employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(string.Format(Constants.EmployeeNotFound, employeeId));
            }

            employee.Address = address;

            context.SaveChanges();

            TModel employeeDto = mapper.Map<TModel>(employee);

            return employeeDto;
        }

        public TModel SetBirthday<TModel>(int employeeId, string date)
        {
            Employee employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(string.Format(Constants.EmployeeNotFound, employeeId));
            }

            employee.Birthday = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            context.SaveChanges();

            TModel employeeDto = mapper.Map<TModel>(employee);

            return employeeDto;
        }

        public TModel SetManager<TModel>(int employeeId, int managerId)
        {
            Employee employee = context.Employees.Find(employeeId);
            if (employee == null)
            {
                throw new ArgumentException(string.Format(Constants.EmployeeNotFound, employeeId));
            }

            Employee manager = context.Employees.Find(managerId);
            if (manager == null)
            {
                throw new ArgumentException(string.Format(Constants.EmployeeNotFound, managerId));
            }

            employee.Manager = manager;

            context.SaveChanges();

            TModel employeeDto = mapper.Map<TModel>(employee);

            return employeeDto;
        }

        public TModel ManagerInfo<TModel>(int managerId)
        {
            TModel managerDto = context.Employees
                .Where(m => m.Id == managerId)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .SingleOrDefault();

            if (managerDto == null)
            {
                throw new ArgumentException(string.Format(Constants.EmployeeNotFound, managerId));
            }

            return managerDto;
        }

        public TModel[] EmployeeOlderThan<TModel>(int age)
        {
            TModel[] projectionDtos = context.Employees
                .Where(e => (DateTime.Now - e.Birthday).Days > age * 365)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .ToArray();

            return projectionDtos;
        }
    }
}
