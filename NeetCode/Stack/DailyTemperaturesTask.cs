namespace NeetCode;

/// <summary>
/// You are given an array of integers temperatures where temperatures[i] represents the daily temperatures on the ith day.
///
/// Return an array result where result[i] is the number of days after the ith day before a warmer temperature appears on a future day. If there is no day in the future where a warmer temperature will appear for
/// the ith day, set result[i] to 0 instead.
///
/// Input: temperatures = [30,38,30,36,35,40,28]
/// Output: [1,4,1,2,1,0,0]
/// </summary>
public class DailyTemperaturesTask
{
    public static int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<(int temperature, int index)>();
        var result = new int[temperatures.Length];

        for (var i = 0; i < temperatures.Length; i++)
        {
            var temperature = temperatures[i];
            while (stack.Count > 0 && stack.Peek().temperature < temperature)
            {
                var pair = stack.Pop();

                result[pair.index] = i - pair.index;
            }
            
            stack.Push((temperature, i));
        }

        return result;
    }
}