using DungeonsAndCodeWizards.Constants;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private StringBuilder sb;
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.sb = new StringBuilder();
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    sb.AppendLine(Messages.FinalStats);

                    this.sb.AppendLine(this.dungeonMaster.GetStats());

                    Console.WriteLine(this.sb.ToString().TrimEnd());

                    Environment.Exit(0);
                }

                try
                {
                    string[] inputData = input.Split(' ');
                    string command = inputData[0];
                    string[] args = inputData.Skip(1).ToArray();

                    string result = "";

                    switch (command)
                    {
                        case "JoinParty":
                            result = this.dungeonMaster.JoinParty(args);
                            break;
                        case "AddItemToPool":
                            result = this.dungeonMaster.AddItemToPool(args);
                            break;
                        case "PickUpItem":
                            result = this.dungeonMaster.PickUpItem(args);
                            break;
                        case "UseItem":
                            result = this.dungeonMaster.UseItem(args);
                            break;
                        case "UseItemOn":
                            result = this.dungeonMaster.UseItemOn(args);
                            break;
                        case "GiveCharacterItem":
                            result = this.dungeonMaster.GiveCharacterItem(args);
                            break;
                        case "GetStats":
                            result = this.dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = this.dungeonMaster.Attack(args);
                            break;
                        case "Heal":
                            result = this.dungeonMaster.Heal(args);
                            break;
                        case "EndTurn":
                            result = this.dungeonMaster.EndTurn(args);

                            if (this.dungeonMaster.IsGameOver())
                            {
                                this.sb.AppendLine(result);

                                sb.AppendLine(Messages.FinalStats);
                                this.sb.AppendLine(this.dungeonMaster.GetStats());

                                Console.WriteLine(this.sb.ToString().TrimEnd());

                                Environment.Exit(0);
                            }
                            break;
                    }

                    this.sb.AppendLine(result);
                }
                catch (ArgumentException ae)
                {
                    this.sb.AppendLine("Parameter Error: " + ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    this.sb.AppendLine("Invalid Operation: " + ioe.Message);
                }
            }
        }
    }
}
