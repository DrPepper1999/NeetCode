namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/727/
/// Дан целочисленный массив nums, отсортированный в неубывающем порядке , удалить дубликаты на месте так, чтобы каждый
/// уникальный элемент появлялся только один раз . Относительный порядок элементов должен оставаться прежним . Затем вернуть
/// количество уникальных элементов в nums 
/// </summary>
public class RemoveDuplicatesFromSortedArray
{
    public int RemoveDuplicates(int[] nums)
    {
        var left = nums.Length > 0 ? 1 : 0;
        foreach (var n in nums)
        {
            if (n > nums[left - 1])
            {
                nums[left++] = n;
            }
        }

        return left;
    }
}