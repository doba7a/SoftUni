public class CommandExecutor : IExecutor
{
    private ICommand command;

    public void ExecuteCommand(ICommand command)
    {
        this.command.Execute();
    }
}