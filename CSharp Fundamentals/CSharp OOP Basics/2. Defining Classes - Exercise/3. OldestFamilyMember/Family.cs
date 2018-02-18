using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> familyMembers;

    public Family()
    {
        this.FamilyMembers = new List<Person>();
    }

    public List<Person> FamilyMembers { get => familyMembers; set => familyMembers = value; }

    public void AddMembers(Person personToAdd)
    {
        this.FamilyMembers.Add(personToAdd);
    }

    public Person GetOldestMember()
    {
        return this.FamilyMembers.OrderByDescending(p => p.Age).FirstOrDefault();
    }
}

