namespace NeetCode;

/// <summary>
/// Вам дан целочисленный массив heights, где heights[i] представляет высоту
/// Вы можете выбрать любые два бруска, чтобы сформировать контейнер. Возвращает
/// максимальное количество воды, которое может хранить контейнер.
/// </summary>
public class ContainerWithMostWater
{
    public static int MaxArea(int[] heights)
    {
        var max = 0;
        
        var left = 0;
        var right = heights.Length - 1;
        while (left < right)
        {
            var width = (right - left);
            var area = Math.Min(heights[left], heights[right]) * width;
            if (area > max)
            {
                max = area;
            }

            if (heights[left] == heights[right])
            {
                left++;
                right--;
                continue;
            }
            
            if (heights[left] < heights[right])
            {
                left++;
            }
            else
            {
                right--;
            }
            
        }

        return max;
    }
}