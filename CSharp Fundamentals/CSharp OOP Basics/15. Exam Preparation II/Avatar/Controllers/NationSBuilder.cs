using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nationsData;
    private List<string> warsData;

    public NationsBuilder()
    {
        this.nationsData = new Dictionary<string, Nation>()
        {
                { "Air", new Nation() },
                { "Water", new Nation() },
                { "Fire" , new Nation() },
                { "Earth", new Nation() }
        };
        this.warsData = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParameter = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                this.nationsData["Air"].Benders.Add(new AirBender(name, power, secondaryParameter));
                break;
            case "Water":
                this.nationsData["Water"].Benders.Add(new WaterBender(name, power, secondaryParameter));
                break;
            case "Fire":
                this.nationsData["Fire"].Benders.Add(new FireBender(name, power, secondaryParameter));
                break;
            case "Earth":
                this.nationsData["Earth"].Benders.Add(new EarthBender(name, power, secondaryParameter));
                break;
        }

    }
    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                this.nationsData["Air"].Monuments.Add(new AirMonument(name, affinity));
                break;
            case "Water":
                this.nationsData["Water"].Monuments.Add(new WaterMonument(name, affinity));
                break;
            case "Fire":
                this.nationsData["Fire"].Monuments.Add(new FireMonument(name, affinity));
                break;
            case "Earth":
                this.nationsData["Earth"].Monuments.Add(new EarthMonument(name, affinity));
                break;
        }
    }
    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{nationsType} Nation")
            .Append(this.nationsData[nationsType].ToString());

        return sb.ToString().Trim();
    }
    public void IssueWar(string nationsType)
    {
        warsData.Add($"War {warsData.Count + 1} issued by {nationsType}");

        double maxPower = this.nationsData.Max(n => n.Value.GetNationPower());

        double airNationPower = this.nationsData["Air"].GetNationPower();
        double waterNationPower = this.nationsData["Water"].GetNationPower();
        double fireNationPower = this.nationsData["Fire"].GetNationPower();
        double earthNationPower = this.nationsData["Earth"].GetNationPower();

        if (airNationPower == maxPower)
        {
            this.nationsData["Water"] = new Nation();
            this.nationsData["Fire"] = new Nation();
            this.nationsData["Earth"] = new Nation();
        }
        else if (waterNationPower == maxPower)
        {
            this.nationsData["Air"] = new Nation();
            this.nationsData["Fire"] = new Nation();
            this.nationsData["Earth"] = new Nation();
        }
        else if (fireNationPower == maxPower)
        {
            this.nationsData["Air"] = new Nation();
            this.nationsData["Water"] = new Nation();
            this.nationsData["Earth"] = new Nation();
        }
        else if (earthNationPower == maxPower)
        {
            this.nationsData["Air"] = new Nation();
            this.nationsData["Water"] = new Nation();
            this.nationsData["Fire"] = new Nation();
        }
    }
    public string GetWarsRecord()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string record in this.warsData)
        {
            sb.AppendLine(record);
        }

        return sb.ToString().Trim();
    }
}

