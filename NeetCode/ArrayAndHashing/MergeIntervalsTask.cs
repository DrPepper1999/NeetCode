namespace NeetCode;

/// <summary>
/// Соеденить интервалы
/// </summary>
public class MergeIntervalsTask
{
    public int[][] MergeIntervals(int[][] intervals)
    {
        // [[1,3], [1,6], [8, 10], [15, 18]]
        var sortedIntervals = intervals
            .OrderBy(i => i[0])
            .ThenBy(i => i[1])
            .ToArray();
        
        var result = new List<int[]>();
        result.Add(sortedIntervals[0]);
        foreach (var interval in sortedIntervals.Skip(1))
        {
            var lastInterval = result.Last();
            if (lastInterval[1] >= interval[0])
            {
                lastInterval[1] = interval[1];
            }
            else
            {
                result.Add(interval);
            }
        }

        return result.ToArray();
    }
}