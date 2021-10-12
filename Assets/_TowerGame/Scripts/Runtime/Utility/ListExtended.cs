using System.Collections.Generic;

public static class ListExtended
{
    public static List<T> Random<T>(this List<T> list, int count)
    {
        List<T> randoms = new List<T>();
        List<T> copy = new List<T>(list);
        for (int i = 0; i < count; i++)
        {
            int index = UnityEngine.Random.Range(0, copy.Count);
            T elem = copy[index];
            copy.RemoveAt(index);
            randoms.Add(elem);
        }

        return randoms;
    }
}