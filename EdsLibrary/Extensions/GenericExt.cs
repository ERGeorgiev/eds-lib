namespace EdsLibrary.Extensions;

/// <summary>
/// Extension to generic objects.
/// </summary>
public static partial class GenericExt
{
    /// <summary>
    /// Removes the element at the given index.
    /// </summary>
    public static T[] RemoveAt<T>(this T[] array, int removalIndex)
    {
        T[] newIndicesArray = new T[array.Length - 1];

        int j = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i != removalIndex)
            {
                newIndicesArray[j] = array[i];
                j++;
            }
        }

        return array;
    }
}
