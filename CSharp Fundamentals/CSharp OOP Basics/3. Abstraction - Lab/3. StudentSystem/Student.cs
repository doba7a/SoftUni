public class Student
{
    private string name;
    private int age;
    private double grade;

    public Student(string name, int age, double grade)
    {
        this.Name = name;
        this.Age = age;
        this.Grade = grade;
    }

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public double Grade { get => grade; set => grade = value; }
}
