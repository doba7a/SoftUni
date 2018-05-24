public class StartUp
{
    public static void Main()
    {
        Robot robot = new Robot("terminator", 100);
        Employee employee = new Employee("pesho");

        robot.RobotWork(20);
        robot.Recharge();

        employee.EmployeeWork(42341);
        employee.Sleep();
    }
}

