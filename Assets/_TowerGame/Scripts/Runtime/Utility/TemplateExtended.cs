using System.Collections.Generic;

public static class TemplateExtended
{
    public static List<T> ToList<T>(this T item)
    {
        return new List<T> {item};
    }
}