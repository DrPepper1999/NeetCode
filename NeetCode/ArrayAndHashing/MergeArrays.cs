namespace NeetCode;

/// <summary>
/// Соеденить массивы
/// </summary>
public class MergeArrays
{
    public static int[] Merge(params int[][] arrays)
    {
        var result = new int[arrays.Sum(a => a.Length)];

        var index = 0;
        for (var i = 0; i < arrays.Length; i++)
        {
            var array = arrays[i];
            for (var j = 0; j < array.Length; j++)
            {
                result[index] = array[j];
                index++;
            }
        }

        return result;
    }
}