namespace Exercise.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] args);
    }
}
