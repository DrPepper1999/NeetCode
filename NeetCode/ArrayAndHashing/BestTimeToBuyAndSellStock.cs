namespace NeetCode.SlidingWindow;

/// <summary>
/// Вам дают целочисленные цены, где цены [i] - это цена Neetcoin в день.
/// Вы можете выбрать один день, чтобы купить один Neetcoin и выбрать другой день в будущем, чтобы продать его.
////
/// Возврат максимальной прибыли, которую вы можете получить. Вы можете не совершать никаких транзакций, в
/// какой случай прибыль будет 0.
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