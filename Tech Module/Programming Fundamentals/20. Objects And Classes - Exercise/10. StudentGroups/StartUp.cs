namespace StudentGroups
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class StudentGroups
    {
        public static void Main()
        {
            List<Town> listOfTowns = new List<Town>();

            string inputData = Console.ReadLine();

            Regex townPattern = new Regex(@"(.+)? => (\d+) seats");

            while (inputData != "End")
            {
                if (inputData.Contains("=>"))
                {
                    Match currentTownData = townPattern.Match(inputData);

                    string currentTownName = currentTownData.Groups[1].Value;
                    int currentTownSeats = int.Parse(currentTownData.Groups[2].Value);

                    Town currentTown = new Town()
                    {
                        Name = currentTownName,
                        SeatsCount = currentTownSeats,
                        Students = new List<Student>()
                    };

                    listOfTowns.Add(currentTown);
                }

                else
                {
                    string[] currentStudentData = inputData.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                    string currentStudentName = currentStudentData[0] + " " + currentStudentData[1];
                    string currentStudentEmail = currentStudentData[2];
                    DateTime currentStudentRegistrationDate = 
                        DateTime.ParseExact(currentStudentData[3], "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    Student currentStudent = new Student()
                    {
                        Name = currentStudentName,
                        Email = currentStudentEmail,
                        RegistrationDate = currentStudentRegistrationDate
                    };

                    listOfTowns.Last().Students.Add(currentStudent);
                }

                inputData = Console.ReadLine();
            }

            List<Group> distributedStudents = new List<Group>();

            foreach (Town town in listOfTowns.OrderBy(x => x.Name))
            {
                List<Student> currentTownDistributedStudents = town.Students
                    .OrderBy(x => x.RegistrationDate)
                    .ThenBy(x => x.Name)
                    .ThenBy(x => x.Email)
                    .ToList();

                while (currentTownDistributedStudents.Any())
                {
                    Town currentGroupTown = town;
                    List<Student> currentGroupStudents = currentTownDistributedStudents.Take(currentGroupTown.SeatsCount).ToList();

                    Group currentGroup = new Group()
                    {
                        Town = currentGroupTown,
                        Students = currentGroupStudents
                    };

                    distributedStudents.Add(currentGroup);

                    currentTownDistributedStudents = currentTownDistributedStudents.Skip(currentGroupTown.SeatsCount).ToList();
                }
            }

            int groupsCount = distributedStudents.Count();
            int townsCount = listOfTowns.Count();

            Console.WriteLine($"Created {groupsCount} groups in {townsCount} towns:");

            foreach (Group group in distributedStudents)
            {
                string currentGroupTown = group.Town.Name;
                List<Student> currentGroupStudents = group.Students;

                List<string> currentGroupEmails = new List<string>();

                foreach (Student student in currentGroupStudents)
                {
                    currentGroupEmails.Add(student.Email);
                }

                Console.WriteLine($"{currentGroupTown} => {string.Join(", ", currentGroupEmails)}");
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }
}