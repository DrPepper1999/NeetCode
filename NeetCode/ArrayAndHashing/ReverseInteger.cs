namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/880/
/// Дано знаковое 32-битное целое число x, вернуть xс обратными цифрами . Если обратный порядок цифр x приводит к выходу
/// значения за пределы знакового 32-битного целого числа, вернуть 0
/// </summary>
public class ReverseInteger
{
    public int Reverse(int x)
    {
        long result = 0;
        while (x != 0)
        {
            result *= 10;
            result += x % 10;
            x = x / 10;
        }
        return (result > Int32.MaxValue || result < Int32.MinValue) ? 0 : (int)result;
    }
}