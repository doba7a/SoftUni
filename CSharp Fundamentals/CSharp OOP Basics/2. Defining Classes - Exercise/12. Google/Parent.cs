using System;

public class Parent
{
    private string name;
    private string birthdayDate;

    public Parent(string nameGiven, string birthdayDateGiven)
    {
        this.Name = nameGiven;
        this.BirthdayDate = birthdayDateGiven;
    }

    public string Name { get => name; set => name = value; }
    public string BirthdayDate { get => birthdayDate; set => birthdayDate = value; }

    public override string ToString()
    {
        return $"{this.Name} {this.BirthdayDate}{Environment.NewLine}";
    }
}
