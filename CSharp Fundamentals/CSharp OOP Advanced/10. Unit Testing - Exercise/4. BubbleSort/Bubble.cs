using System;

public class Bubble
{
    public static void Sort<T>(params T[] A) 
        where T : IComparable
    {
        T U;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = i + 1; j < A.GetLength(0); j++)
            {
                if (A[i].CompareTo(A[j]) > 0)
                {
                    U = A[i];
                    A[i] = A[j];
                    A[j] = U;
                }
            }
        }
    }
}

