namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/
/// Дан непустой  массив целых чисел nums, каждый элемент встречается дважды, за исключением одного. Найдите этот единственный.
/// Необходимо реализовать решение с линейной сложностью выполнения и использовать только постоянное дополнительное
///пространство.
/// </summary>
public class SingleNumberTask
{
    public int SingleNumber(int[] nums)
    {
        var result = 0;

        foreach (var n in nums)
        {
            result ^= n; // Побитовое исключающие или
        }

        return result;
    }
}