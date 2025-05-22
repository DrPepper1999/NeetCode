namespace NeetCode;

/// <summary>
/// // Задача: есть нули и единицы в массиве. Надо для каждого нуля посчитать сколько единиц правее него
/// и вывести сумму таких чисел. Сделать за один проход.
/// </summary>
public class CountNumAfterZeroTask
{
    public static int Count(int[] arr)
    {
        var result = 0;
        var zeroCount = 0;
        for (var i = arr.Length -1; i >= 0; i--)
        {
            if (arr[i] == 0)
            {
                zeroCount++;
            }
            else
            {
                result += zeroCount;
            }
        }

        return result;
    }
}