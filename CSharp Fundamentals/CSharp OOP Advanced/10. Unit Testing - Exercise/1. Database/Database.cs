using System;

public class Database : IDatabase
{
    private const int DEFAULT_CAPACITY = 16;

    private int[] values;
    private int nextFreeCellIndex;
    private int indexOfLastElement;

    public Database(int[] values)
    {
        this.values = CheckValues(values);
        this.nextFreeCellIndex = 16;
        this.indexOfLastElement = 15;
    }

    public void Add(int value)
    {
        if (nextFreeCellIndex == DEFAULT_CAPACITY)
        {
            throw new InvalidOperationException("Database can't store more than 16 integers.");
        }

        int[] tempArray = new int[this.values.Length + 1];
        for (int i = 0; i < this.values.Length; i++)
        {
            tempArray[i] = this.values[i];
        }
        tempArray[nextFreeCellIndex] = value;

        this.values = tempArray;
        nextFreeCellIndex++;
        indexOfLastElement++;
    }

    public int[] Fetch()
    {
        return this.values;
    }

    public void Remove()
    {
        if (this.values.Length == 0)
        {
            throw new InvalidOperationException("Database already empty. No elements to remove.");
        }

        int[] tempArray = new int[this.values.Length - 1];
        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = this.values[i];
        }

        this.values = tempArray;
        nextFreeCellIndex--;
        indexOfLastElement--;
    }

    public int GetDatabaseLength()
    {
        return this.values.Length;
    }

    private int[] CheckValues(int[] values)
    {
        if (values.Length != DEFAULT_CAPACITY)
        {
            throw new InvalidOperationException("Size of the array must be exactly 16 integers long.");
        }

        return values;
    }
}

