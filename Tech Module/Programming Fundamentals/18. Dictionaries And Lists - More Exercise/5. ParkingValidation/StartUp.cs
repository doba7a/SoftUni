namespace ParkingValidation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ParkingValidation
    {
        public static void Main()
        {
            Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] currentInput = Console.ReadLine().Split(' ');

                string currentCommand = currentInput[0];

                if (currentCommand == "register")
                {
                    string currentUsername = currentInput[1];
                    string currentLicensePlateNumber = currentInput[2];

                    RegisterUser(currentUsername, currentLicensePlateNumber, registeredUsers);
                }
                else if (currentCommand == "unregister")
                {
                    string currentUsername = currentInput[1];

                    UnregisterUser(currentUsername, registeredUsers);
                }
            }

            foreach (var user in registeredUsers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }

        public static void RegisterUser(string currentUsername, string currentLicensePlateNumber, Dictionary<string, string> registeredUsers)
        {
            if (registeredUsers.ContainsKey(currentUsername))
            {
                Console.WriteLine($"ERROR: already registered with plate number {registeredUsers[currentUsername]}");
            }
            else if (currentLicensePlateNumber.Length != 8
                       || !currentLicensePlateNumber.Substring(0, 2).All(c => char.IsUpper(c))
                       || !currentLicensePlateNumber.Substring(6, 2).All(c => char.IsUpper(c))
                       || !currentLicensePlateNumber.Substring(2, 4).All(c => char.IsDigit(c)))
            {
                Console.WriteLine($"ERROR: invalid license plate {currentLicensePlateNumber}");
            }
            else if (registeredUsers.ContainsValue(currentLicensePlateNumber))
            {
                Console.WriteLine($"ERROR: license plate {currentLicensePlateNumber} is busy");
            }
            else
            {
                registeredUsers.Add(currentUsername, currentLicensePlateNumber);
                Console.WriteLine($"{currentUsername} registered {currentLicensePlateNumber} successfully");
            }
        }

        public static void UnregisterUser(string currentUsername, Dictionary<string, string> registeredUsers)
        {
            if (!registeredUsers.ContainsKey(currentUsername))
            {
                Console.WriteLine($"ERROR: user {currentUsername} not found");
            }
            else
            {
                Console.WriteLine($"user {currentUsername} unregistered successfully");
                registeredUsers.Remove(currentUsername);
            }
        }
    }
}