namespace NeetCode.SlidingWindow;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/564/
/// </summary>
public class BestTimeToBuyAndSellStock2
{
    public int MaxProfit(int[] prices) {
        var profit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                profit += prices[i] - prices[i - 1];
            }
        }

        return profit;
    }
}