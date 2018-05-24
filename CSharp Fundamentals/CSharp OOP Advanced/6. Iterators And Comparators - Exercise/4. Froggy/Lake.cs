using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private readonly List<int> stoneNumbers;

    public Lake(int[] stoneNumbers)
    {
        this.stoneNumbers = new List<int>(stoneNumbers);
    }

    public IEnumerator<int> GetEnumerator()
    {
        int index = this.stoneNumbers.Count;

        for (int i = 0; i < index; i += 2)
        {
            yield return this.stoneNumbers[i];
        }

        if (this.stoneNumbers.Count % 2 != 0)
        {
            index -= 2;
        }
        else
        {
            index--;
        }

        for (int i = index; i >= 0; i -= 2)
        {
            yield return this.stoneNumbers[i];
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

