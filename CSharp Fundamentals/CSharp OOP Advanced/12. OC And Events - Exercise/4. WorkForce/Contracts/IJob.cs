using System;

public interface IJob
{
    string Name { get; }

    int HoursOfWorkRequired { get; }

    IEmployee Employee { get; }

    bool JobDone { get; }

    bool Update();

    event EventHandler JobDoneEventHandler;

    void OnJobDone(object sender, EventArgs e);
}

