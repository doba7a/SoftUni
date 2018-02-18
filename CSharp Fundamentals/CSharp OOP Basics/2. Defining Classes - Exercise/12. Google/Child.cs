using System;

public class Child
{
    private string name;
    private string birthdayDate;

    public Child(string nameGiven, string birthdayDateGiven)
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
