namespace NeetCode.SlidingWindow;

/// <summary>
/// You are given an integer array prices where prices[i] is the price of NeetCoin on the ith day.
/// You may choose a single day to buy one NeetCoin and choose a different day in the future to sell it.
///
/// Return the maximum profit you can achieve. You may choose to not make any transactions, in
/// which case the profit would be 0.
/// </summary>
public class BestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices) {
        var start = 0;
        var maxSellesPrice = 0;
        for (var end = 1; end < prices.Length; end++)
        {
            var sellesPrice = prices[end] - prices[start];

            if (sellesPrice > maxSellesPrice)
            {
                maxSellesPrice = sellesPrice;
            }

            if (prices[end] < prices[start])
            {
                start = end;
            }
        }

        return maxSellesPrice;
    }
}