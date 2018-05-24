using System;
using System.Collections.Generic;
using System.Linq;

public class JobRepository : List<IJob>
{
    public void OnJobDone(object sender, EventArgs e)
    {
        this.Remove(this.First(j => j.JobDone == true));
    }
}

