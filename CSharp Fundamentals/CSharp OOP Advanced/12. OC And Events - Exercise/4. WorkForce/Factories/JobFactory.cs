using System;

public class JobFactory : IJobFactory
{
    public IJob CreateJob(string jobType, string jobName, int hoursOfWorkRequired, IEmployee employee)
    {
        Type classType = Type.GetType(jobType);

        IJob currentJob = (IJob)Activator.CreateInstance(classType, new object[] { jobName, hoursOfWorkRequired, employee });

        return currentJob;
    }
}

