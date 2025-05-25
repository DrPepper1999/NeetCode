namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/
/// Вам дано большое целое число , представленное в виде массива целых чисел digits, где каждая цифра digits[i]— это цифра
/// целого числа. Цифры упорядочены от наиболее значимых к наименее значимым слева направо. Большое целое число не содержит начальных 0
/// Нужно прибавить 1 к цифре 
/// </summary>
public class PlusOneTask
{
    public int[] PlusOne(int[] digits) {
        for (var i = digits.Length-1; i >= 0; i--) {
            if (digits[i] != 9) {
                digits[i]++;
                return digits;
            }
            
            digits[i] = 0;
        }
        
        if (digits[0] == 0) {
            var result = new int[digits.Length + 1];
            result[0] = 1;
            return result;
        }
        
        return digits;
    }
}