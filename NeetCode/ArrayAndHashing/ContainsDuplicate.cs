namespace NeetCode;

/// <summary>
/// Вывести true сли массив содержит дубликаты, иначе false
/// </summary>
public class ContainsDuplicate
{
    public bool hasDuplicate(int[] nums)
    {
        var uniqueNumbers = new HashSet<int>();

        foreach (var num in nums)
        {
            if (!uniqueNumbers.Add(num))
            {
                return true;
            }
        }

        return false;
    }
}