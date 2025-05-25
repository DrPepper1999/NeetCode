namespace NeetCode;

// <summary>
// Учитывая массив целых чисел, верните длину самой длинной последовательной последовательности элементов
// Это можно сформировать.
//
// последовательная последовательность - это последовательность элементов, в которых каждый элемент точно на 1 больше, чем
// предыдущий элемент. Элементы не должны быть последовательными в оригинальном массиве.
//
/// Вы должны написать алгоритм, который работает во время O (n).
///
/// Input: nums = [2,20,4,10,3,4,5]
/// Output: 4
///
/// Input: nums = [0,3,2,5,4,6,1,1]
/// Output: 7
/// </summary>
public class LongestConsecutiveSequence
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        var hashNums = nums.ToHashSet();

        var starts = nums.Where(num => !hashNums.Contains(num - 1));

        var result = starts.Select(num =>
        {
            var result = 0;
            while (hashNums.Contains(num + result))
            {
                result++;
            }

            return result;
        })
        .Max();

        return result;
    }
}
