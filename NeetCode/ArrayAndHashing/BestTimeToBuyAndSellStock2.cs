namespace NeetCode.SlidingWindow;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/564/
/// Вам дан целочисленный массив, pricesгде prices[i]— цена определенной акции на день.ith
/// Каждый день вы можете решить купить и/или продать акции. Вы можете держать только одну акцию акций в любой момент времени.
/// Однако вы можете купить ее, а затем немедленно продать в тот же день .
/// Найдите и получите максимальную прибыль , которую только можете получить .
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