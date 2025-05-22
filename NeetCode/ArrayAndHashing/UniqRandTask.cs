namespace NeetCode;

/// <summary>
/// Написать функции которая возращает n уникальных чисел
/// </summary>
public class UniqRandTask
{
    public static int[] UniqRand(int n)
    {
        var values = new HashSet<int>();

        var randomizer = new Random();

        for (var i = 0; i < n; i++)
        {
            var randomValue = randomizer.Next();

            while (values.Contains(randomValue))
            {
                randomValue = randomizer.Next();
            }

            values.Add(randomValue);
        }

        return values.ToArray();
    }
}