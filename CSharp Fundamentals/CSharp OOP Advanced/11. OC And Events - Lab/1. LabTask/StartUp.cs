public class StartUp
{
    public static void Main()
    {
        IHandler combatLogger = new CombatLogger();
        IHandler eventLogger = new EventLogger();

        combatLogger.SetSuccessor(eventLogger);

        IAttackGroup attackGroup = new Group();

        IAttacker attacker1 = new Warrior("Gosho", 30, combatLogger);
        IAttacker attacker2 = new Warrior("Pesho", 40, combatLogger);

        attackGroup.AddMember(attacker1);
        attackGroup.AddMember(attacker2);

        Subject subject = new Subject(122);
        subject.Register(new Observer(attacker2));
        subject.Register(new Observer(attacker1));

        ITarget target = new Dragon("GoshoOtPochivka", 800, 122, combatLogger);

        IExecutor executor = new CommandExecutor();
        ICommand targetCommand = new GroupTargetCommand(attackGroup, target);
        targetCommand.Execute();
        ICommand attackCommand = new GroupAttackCommand(attackGroup);
        attackCommand.Execute();
        subject.NotifyObservers();
    }
}

