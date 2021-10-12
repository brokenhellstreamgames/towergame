using System.Collections.Generic;

public static class LinqExtended
{
    public static List<T> ToList<T>(this IEnumerable<T> TSource)
    {
        List<T> newList = new List<T>();
        foreach (T item in TSource)
        {
            newList.Add(item);
        }

        return newList;
    }
}