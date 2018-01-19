namespace MentorGroup
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    public class MentorGroup
    {
        public static void Main()
        {
            SortedDictionary<string, Student> studentsData = new SortedDictionary<string, Student>();

            string studentAttendances = Console.ReadLine();

            while (studentAttendances != "end of dates")
            {
                string[] currentStudentData = studentAttendances.Split(' ', ',');

                string currentStudentName = currentStudentData[0];

                if (!studentsData.ContainsKey(currentStudentName))
                {
                    studentsData[currentStudentName] = new Student();
                }

                if (currentStudentData.Length == 1)
                {
                    studentAttendances = Console.ReadLine();
                    continue;
                }

                List<DateTime> currentStudentAttendance =
                    currentStudentData
                    .Skip(1)
                    .Select(x => DateTime.ParseExact(x.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                    .ToList();

                if (studentsData[currentStudentName].DatesAttended == null)
                {
                    studentsData[currentStudentName].DatesAttended = new List<DateTime>();
                }

                studentsData[currentStudentName].DatesAttended.AddRange(currentStudentAttendance);

                studentAttendances = Console.ReadLine();
            }

            string studentComments = Console.ReadLine();

            while (studentComments != "end of comments")
            {
                string[] currentStudentCommentsData = studentComments.Split('-');

                string currentStudentName = currentStudentCommentsData[0];

                if (!studentsData.ContainsKey(currentStudentName))
                {
                    studentComments = Console.ReadLine();
                    continue;
                }

                string currentStudentComment = currentStudentCommentsData[1];

                if (studentsData[currentStudentName].Comments == null)
                {
                    studentsData[currentStudentName].Comments = new List<string>();
                }

                studentsData[currentStudentName].Comments.Add(currentStudentComment);

                studentComments = Console.ReadLine();
            }

            foreach (var student in studentsData)
            {
                Console.WriteLine($"{student.Key}{Environment.NewLine}Comments:");

                if (student.Value.Comments != null)
                {
                    foreach (var comment in student.Value.Comments)
                    {
                        Console.WriteLine($"- {comment}");
                    }
                }              

                Console.WriteLine("Dates attended:");

                if (student.Value.DatesAttended != null)
                {
                    foreach (var dateAttended in student.Value.DatesAttended.OrderBy(x => x))
                    {
                        Console.WriteLine($"-- {dateAttended.Day:D2}/{dateAttended.Month:D2}/{dateAttended.Year:D4}");
                    }
                }
            }
        }
    }

    public class Student
    {
        public List<string> Comments { get; set; }
        public List<DateTime> DatesAttended { get; set; }
    }
}