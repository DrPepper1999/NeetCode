namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/674/
/// </summary>
public class IntersectionOfTwoArraysII
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var map = new Dictionary<int, int>();
        
        foreach(var n in nums1) {
            if (!map.TryAdd(n, 1)) {
                map[n]++;
            }
        }
        
        var result = new List<int>();
        foreach(var n in nums2) {
            if (map.TryGetValue(n, out var value) && value > 0) {
                result.Add(n);
                map[n]--;
            }
            
        }
        
        return result.ToArray();
    }
    
}