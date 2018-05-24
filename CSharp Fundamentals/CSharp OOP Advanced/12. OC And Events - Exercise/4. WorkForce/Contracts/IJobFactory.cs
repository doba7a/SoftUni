public interface IJobFactory
{
    IJob CreateJob(string jobType, string jobName, int hoursOfWorkRequired, IEmployee employee);
}

