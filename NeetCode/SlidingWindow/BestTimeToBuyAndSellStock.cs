namespace NeetCode.SlidingWindow;

/*
You are given an integer array prices where prices[i] is the price of NeetCoin on the ith day.
You may choose a single day to buy one NeetCoin and choose a different day in the future to sell it.
Return the maximum profit you can achieve. You may choose to not make any transactions, in which case the profit would be 0.

Input: prices = [10,1,5,6,7,1]
Output: 6

Input: prices = [10,8,7,5,2]
Output: 0
 */
public class BestTimeToBuyAndSellStock
{
    public static int MaxProfit(int[] prices)
    {
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