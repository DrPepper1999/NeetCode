namespace NeetCode;

/// <summary>
/// Вам дают массив целых чисел температуры, при которых температура [i] представляет ежедневные температуры в день.
////
/// Вернуть результат массива, когда результат [i] - это количество дней после того, как в день более теплой температуры
/// появится в будущий день. Если в будущем нет дня, когда появится более теплая температура
/// Вместо этого дня установите результат [i] на 0.
///
/// Input: temperatures = [30,38,30,36,35,40,28]
/// Output: [1,4,1,2,1,0,0]
///
/// /// Input: temperatures = [30,38,30,26,35,40,28]
/// Output: [1,4,2,1,1,0,0]
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