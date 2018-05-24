public interface ISubject
{
    void Register(Observer observer);

    void Unregister(Observer observer);

    void NotifyObservers();
}
