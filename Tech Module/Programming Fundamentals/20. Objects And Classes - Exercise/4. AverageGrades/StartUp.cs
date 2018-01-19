namespace AverageGrades
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class AverageGrades
    {
        public static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> listOfStudents = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] currentStudentData = Console.ReadLine().Split(' ');

                string currentStudentName = currentStudentData[0];
                List <double> currentStudentGrades = currentStudentData.Skip(1).Select(double.Parse).ToList();

                Student currentStudent = new Student
                {
                    Name = currentStudentName,
                    ListOfGrades = currentStudentGrades
                };

                listOfStudents.Add(currentStudent);
            }

            foreach (Student student in listOfStudents
                .Where(x => x.AverageGrade >= 5.00)
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.AverageGrade))
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public List<double> ListOfGrades { get; set; }
        public double AverageGrade => ListOfGrades.Average();
    }
}