using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> Repo
    {
        get { return repo; }
        private set { repo = value; }
    }

    public void ParseCommand()
    {
        string[] studentData = Console.ReadLine().Split();

        if (studentData[0] == "Create")
        {
            CreateStudent(studentData);
        }
        else if (studentData[0] == "Show")
        {
            ShowStudent(studentData);
        }
        else if (studentData[0] == "Exit")
        {
            Environment.Exit(0);
        }
    }

    private void CreateStudent(string[] studentData)
    {
        string name = studentData[1];
        int age = int.Parse(studentData[2]);
        double grade = double.Parse(studentData[3]);

        if (!repo.ContainsKey(name))
        {
            Student student = new Student(name, age, grade);

            Repo[name] = student;
        }
    }

    private void ShowStudent(string[] studentData)
    {
        string name = studentData[1];

        if (Repo.ContainsKey(name))
        {
            Student student = Repo[name];
            string view = $"{student.Name} is {student.Age} years old.";

            if (student.Grade >= 5.00)
            {
                view += " Excellent student.";
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                view += " Average student.";
            }
            else
            {
                view += " Very nice person.";
            }

            Console.WriteLine(view);
        }
    }
}
