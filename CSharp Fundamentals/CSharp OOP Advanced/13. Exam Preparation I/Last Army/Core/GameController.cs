using System;
using System.Linq;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        string[] inputData = input.Split();
        string command = inputData[0];

        if (command.Equals("Soldier"))
        {
            string secondaryParam = inputData[1];

            if (secondaryParam.Equals("Regenerate"))
            {
                string soldierType = inputData[2];

                this.army.RegenerateTeam(soldierType);
            }
            else
            {
                string soldierType = secondaryParam;
                string soldierName = inputData[2];
                int soldierAge = int.Parse(inputData[3]);
                double soldierExperience = double.Parse(inputData[4]);
                double soldierEndurance = double.Parse(inputData[5]);

                ISoldier currentSoldier = this.soldierFactory.CreateSoldier(soldierType, soldierName, soldierAge, soldierExperience, soldierEndurance);

                if (this.wareHouse.TryEquipSoldier(currentSoldier))
                {
                    this.army.AddSoldier(currentSoldier);
                }
                else
                {
                    throw new ArgumentException(string.Format(OutputMessages.NoWeaponForSoldier, soldierType, soldierName));
                }
            }
        }
        else if (command.Equals("WareHouse"))
        {
            string ammunitionType = inputData[1]; ;
            int ammunitionQunatity = int.Parse(inputData[2]);

            this.wareHouse.AddAmmunitions(ammunitionType, ammunitionQunatity);
        }
        else if (inputData[0].Equals("Mission"))
        {
            string missionType = inputData[1]; ;
            double missionScore = double.Parse(inputData[2]);

            IMission currentMission = this.missionFactory.CreateMission(missionType, missionScore);

            string result = this.missionController.PerformMission(currentMission).Trim();

            this.writer.AppendLine(result);
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();

        writer.AppendLine(OutputMessages.Results);
        writer.AppendLine(string.Format(OutputMessages.SuccessfulMissions, this.missionController.SuccessMissionCounter));
        writer.AppendLine(string.Format(OutputMessages.FailedMissions, this.missionController.FailedMissionCounter));
        writer.AppendLine(OutputMessages.Soldiers);
        foreach (ISoldier soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            writer.AppendLine(soldier.ToString());
        }
    }
}
