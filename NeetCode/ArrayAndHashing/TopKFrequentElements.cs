namespace NeetCode;

/// <summary>
/// Дан массив целых чисел nums и целое число k, вернуть k наиболее часто встречающиеся элементы в массиве.
///
/// Вы можете вернуть выходные данные в любом порядке.
///
/// Input: nums = [1,2,2,3,3,3], k = 2
/// Output: [2,3]
///
/// Input: nums = [7,7], k = 1
/// Output: [7]
/// </summary>
public class TopKFrequentElements // TODO описать решение
{
    // Через PriorityQueue  Time complexity: O(nlogk),  Space complexity: O(n+k)
    // Простое решение
    public int[] TopKFrequentMinHeap(int[] nums, int k) {
        var count = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (!count.TryAdd(num, 1)) {
                count[num]++;
            }
        }

        var heap = new PriorityQueue<int, int>();
        foreach (var entry in count) {
            heap.Enqueue(entry.Key, entry.Value);
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }
        
        var res = new int[k];
        for (int i = 0; i < k; i++) {
            res[i] = heap.Dequeue();
        }
        return res;
    }
    
    // Time complexity: O(n), Space complexity: O(n)
    public int[] TopKFrequentBucketSort(int[] nums, int k) {
        var count = new Dictionary<int, int>();
        var freq = new List<int>[nums.Length + 1];
        for (int i = 0; i < freq.Length; i++) {
            freq[i] = new List<int>();
        }

        foreach (var n in nums) {
            if (!count.TryAdd(n, 1)) {
                count[n]++;
            }
        }
        foreach (var entry in count){
            freq[entry.Value].Add(entry.Key);
        }

        var res = new int[k];
        var index = 0;
        for (var i = freq.Length - 1; i > 0 && index < k; i--) {
            foreach (var n in freq[i]) {
                res[index++] = n;
                if (index == k) {
                    return res;
                }
            }
        }
        return res;
    }
    
    
    
    public int[] TopKFrequent(int[] nums, int k)
    {
        var blocks = new List<int>[nums.Length+1];

        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i] = new List<int>();
        }
        
        var frequentElements = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!frequentElements.TryAdd(num, 1))
            {
                frequentElements[num] += 1;
            }
        }

        foreach (var element in frequentElements)
        {
            blocks[element.Key].Add(element.Value);
        }

        var result = new List<int>();
        for (var i = nums.Length -1; i > 0; i--)
        {
            if (k <= 0)
            {
                break;
            }
            
            var item = blocks[i];

            if (item.Count <= 0) continue;
            
            result.AddRange(item.Take(k));
            k -= item.Count;
        }

        return result.ToArray();
    }
}