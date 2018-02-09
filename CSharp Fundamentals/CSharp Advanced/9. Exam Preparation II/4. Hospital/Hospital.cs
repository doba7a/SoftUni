namespace Hospital
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Hospital
    {
        public static void Main()
        {
            Dictionary<string, List<string>> departmentsData = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctorsData = new Dictionary<string, List<string>>();

            string currentInput = Console.ReadLine();

            while (currentInput != "Output")
            {
                string[] inputData = currentInput
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string department = inputData[0];
                string doctor = inputData[1] + " " + inputData[2];
                string patient = inputData[3];

                if (!departmentsData.ContainsKey(department))
                {
                    departmentsData[department] = new List<string>();
                }
                if (!doctorsData.ContainsKey(doctor))
                {
                    doctorsData[doctor] = new List<string>();
                }

                if (departmentsData[department].Count < 60)
                {
                    departmentsData[department].Add(patient);
                    doctorsData[doctor].Add(patient);
                }

                currentInput = Console.ReadLine();
            }

            currentInput = Console.ReadLine();

            while (currentInput != "End")
            {
                if (departmentsData.ContainsKey(currentInput))
                {
                    string department = currentInput;
                    foreach (string patient in departmentsData[department])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else if (doctorsData.ContainsKey(currentInput))
                {
                    string doctor = currentInput;
                    foreach (string patient in doctorsData[doctor].OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    string[] inputData = currentInput
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string department = inputData[0];
                    int room = int.Parse(inputData[1]);

                    List<string> patientsToPrint = new List<string>();

                    for (int patient = (room * 3) - 3; patient <= (room * 3) - 1; patient++)
                    {
                        patientsToPrint.Add(departmentsData[department].ElementAtOrDefault(patient));
                    }

                    foreach (string patient in patientsToPrint.OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }

                currentInput = Console.ReadLine();
            }
        }
    }
}
