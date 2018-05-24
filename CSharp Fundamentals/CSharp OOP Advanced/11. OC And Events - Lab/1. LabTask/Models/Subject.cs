using System.Collections.Generic;

public class Subject : ISubject
{
    private List<Observer> observers;
    private int reward;

    public Subject(int reward)
    {
        this.observers = new List<Observer>();
        this.reward = reward;
    }

    public void NotifyObservers()
    {
        foreach (Observer observer in observers)
        {
            observer.Update(this.reward);
        }
    }

    public void Register(Observer observer)
    {
        this.observers.Add(observer);
    }

    public void Unregister(Observer observer)
    {
        this.observers.Remove(observer);
    }
}
