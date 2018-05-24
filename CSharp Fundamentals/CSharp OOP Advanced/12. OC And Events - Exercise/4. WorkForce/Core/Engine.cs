using System;
using System.Linq;

public class Engine
{
    private IEmployeeFactory employeeFactory;
    private IJobFactory jobFactory;
    private EmployeeRepository employeeRepository;
    private JobRepository jobRepository;

    public Engine()
    {
        this.employeeFactory = new EmployeeFactory();
        this.jobFactory = new JobFactory();
        this.employeeRepository = new EmployeeRepository();
        this.jobRepository = new JobRepository();
    }

    public void Run()
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputData = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (inputData[0])
            {
                case "Job":
                    string jobName = inputData[1];
                    int hoursRequired = int.Parse(inputData[2]);
                    IEmployee existingEmployee = this.employeeRepository.First(e => e.Name == inputData[3]);

                    IJob newJob = this.jobFactory.CreateJob(inputData[0], jobName, hoursRequired, existingEmployee);

                    newJob.JobDoneEventHandler += newJob.OnJobDone;
                    newJob.JobDoneEventHandler += this.jobRepository.OnJobDone;

                    this.jobRepository.Add(newJob);

                    break;
                case "StandardEmployee":
                    string standartEmployeeName = inputData[1];

                    IEmployee newStandartEmployee = this.employeeFactory.CreateEmployee(inputData[0], standartEmployeeName);
                    this.employeeRepository.Add(newStandartEmployee);

                    break;
                case "PartTimeEmployee":
                    string partTimeEmployeeName = inputData[1];

                    IEmployee newPartTimeEmployee = this.employeeFactory.CreateEmployee(inputData[0], partTimeEmployeeName);
                    this.employeeRepository.Add(newPartTimeEmployee);

                    break;
                case "Pass":
                    for (int i = 0; i < this.jobRepository.Count; i++)
                    {
                        bool itemDeleted = this.jobRepository[i].Update();
                        if (itemDeleted)
                        {
                            i--;
                        }
                    }

                    break;
                case "Status":
                    foreach (IJob job in this.jobRepository)
                    {
                        Console.WriteLine(job.ToString());
                    }
                    break;
            }

            input = Console.ReadLine();
        }
    }
}

