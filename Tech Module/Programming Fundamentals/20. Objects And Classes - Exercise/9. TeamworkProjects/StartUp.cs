namespace TeamworkProjects
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class TeamworkProjects
    {
        public static void Main()
        {
            List<Team> listOfTeams = new List<Team>();

            int numberOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] currentTeamData = Console.ReadLine().Split('-');

                string teamCreator = currentTeamData[0];
                string teamName = currentTeamData[1];

                if (listOfTeams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (listOfTeams.Any(x => x.CreatorName == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }

                Team currentTeam = new Team
                {
                    Name = teamName,
                    CreatorName = teamCreator
                };

                listOfTeams.Add(currentTeam);

                Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
            }

            string assignment = Console.ReadLine();

            while (assignment != "end of assignment")
            {
                string[] currentAssignment = assignment.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string username = currentAssignment[0];
                string teamName = currentAssignment[1];

                if (!listOfTeams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    assignment = Console.ReadLine();
                    continue;
                }

                if (listOfTeams.Where(x => x.Members != null).Any(x => x.Members.Contains(username))
                    || listOfTeams.Any(x => x.CreatorName == username))
                {
                    Console.WriteLine($"Member {username} cannot join team {teamName}!");
                    assignment = Console.ReadLine();
                    continue;
                }

                if (listOfTeams.First(x => x.Name == teamName).Members == null)
                {
                    listOfTeams.First(x => x.Name == teamName).Members = new List<string>();
                }

                listOfTeams.First(x => x.Name == teamName).Members.Add(username);

                assignment = Console.ReadLine();
            }

            List<Team> validTeams = listOfTeams.Where(x => x.Members != null).ToList();

            foreach (var validTeam in validTeams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{validTeam.Name}{Environment.NewLine}- {validTeam.CreatorName}");

                foreach (var member in validTeam.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            List<Team> invalidTeams = listOfTeams.Where(x => x.Members == null).ToList();

            Console.WriteLine($"Teams to disband:");
            foreach (var invalidTeam in invalidTeams.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }
        }
    }

    public class Team
    {
        public string Name { get; set; }
        public string CreatorName { get; set; }
        public List<string> Members { get; set; }
    }
}