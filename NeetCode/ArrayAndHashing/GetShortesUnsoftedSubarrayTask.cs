namespace NeetCode.SlidingWindow;

/// <summary>
/// На вход подаёться массив целых чисел. Необходимо вернуть индексы начала и конца наименьшего подмассива,
/// после сортировки которого исходный массив станет отсортированым
///               l     r
/// Input: [2, 3, 9, 7, 4, 15]
/// Output: (2, 4)
/// </summary>
public class GetShortestUnsortedSubArrayTask
{
    /// <summary>
    /// Идём по массиву, когда встречаем первый элемент который ломает возрастающию послежовательность
    /// присваеваем на него указатель l(только один первый раз), и указатель r каждый раз
    /// </summary>
    public static (int, int) GetShortestUnsortedSubArray(int[] nums)
    {
        var left = 0;
        var right = 0;
        var max = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] < max)
            {
                if (left == 0)
                {
                    left = i-1;
                }
                right = i;
                continue;
            }
            
            max = nums[i];
        }

        return (left, right);
    }
}