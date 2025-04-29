namespace NeetCode;

public class TopKFrequentElements
{
    public int[] TopKFrequent1(int[] nums, int k) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        List<int>[] freq = new List<int>[nums.Length + 1];
        for (int i = 0; i < freq.Length; i++) {
            freq[i] = new List<int>();
        }

        foreach (int n in nums) {
            if (count.ContainsKey(n)) {
                count[n]++;
            } else {
                count[n] = 1;
            }
        }
        foreach (var entry in count){
            freq[entry.Value].Add(entry.Key);
        }

        int[] res = new int[k];
        int index = 0;
        for (int i = freq.Length - 1; i > 0 && index < k; i--) {
            foreach (int n in freq[i]) {
                res[index++] = n;
                if (index == k) {
                    return res;
                }
            }
        }
        return res;
    }
    
    public int[] TopKFrequent2(int[] nums, int k) {
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