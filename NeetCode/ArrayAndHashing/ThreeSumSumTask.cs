namespace NeetCode;

/// <summary>
/// Учитывая массив целых чисел и целочисленную цель, верните индексы i и j, такие что Nums [i] + nums [j] == Target и i != j.
/// Вы можете предположить, что у каждого ввода есть ровно одна пара индексов i и j, которые удовлетворяют условию.
/// Сначала вернуть ответ с меньшим индексом.
///
/// Input:
/// nums = [3,4,5,6], target = 7
///
/// Output: [0,1]
/// </summary>
public class ThreeSumSumTask
{
    public static List<List<int>> ThreeSum(int[] nums)
    {
        var sortNums = nums.Order().ToArray();

        var result = new List<List<int>>();
        
        for (var i = 0; i < sortNums.Length - 1; i++)
        {
            if (sortNums[i] > 0)
            {
                break;
            }

            if (i > 0 && sortNums[i] == sortNums[i - 1])
            {
                continue;
            }
            
            var left = i + 1;
            var right = nums.Length - 1;
            while (left < right)
            {
                var sum = sortNums[left] + sortNums[right] + sortNums[i];

                if (sum > 0)
                {
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    result.Add(new List<int>() {sortNums[i], sortNums[left], sortNums[right]});
                    left++;
                    right--;
                    while (left < right && sortNums[left] == sortNums[left -1])
                    {
                        left++;
                    }
                }
            }
        }

        return result;
    }
}