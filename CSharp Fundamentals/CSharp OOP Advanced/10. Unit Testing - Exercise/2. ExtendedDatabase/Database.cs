using System;
using System.Collections.Generic;
using System.Linq;

public class Database : IDatabase
{
    private readonly ICollection<Person> personData;

    public Database()
    {
        this.personData = new List<Person>();
    }

    public void Add(Person personToAdd)
    {
        if (this.personData.Any(p => p.Username == personToAdd.Username))
        {
            throw new InvalidOperationException("Username taken.");
        }

        if (this.personData.Any(p => p.Id == personToAdd.Id))
        {
            throw new InvalidOperationException("ID taken.");
        }

        if (personToAdd.Id < 0)
        {
            throw new ArgumentException("ID can't be less than zero.");
        }

        this.personData.Add(personToAdd);
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentException("ID can't be less than zero.");
        }

        Person personToReturn = this.personData.FirstOrDefault(p => p.Id == id);

        if (personToReturn == null)
        {
            throw new InvalidOperationException($"Person with ID: {id} doesn't exist in database.");
        }

        return personToReturn;
    }

    public Person FindByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException(username, "Given username can't be null or empty.");
        }

        Person personToReturn = this.personData.FirstOrDefault(p => p.Username == username);

        if (personToReturn == null)
        {
            throw new InvalidOperationException($"Person with Username: {username} doesn't exist in database.");
        }

        return personToReturn;
    }

    public void Remove()
    {
        if (this.personData.Count == 0)
        {
            throw new InvalidOperationException("Database already empty.");
        }

        this.personData.Remove(this.personData.Last());
    }

    public int GetDbCount()
    {
        return this.personData.Count;
    }
}

