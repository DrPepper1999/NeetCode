namespace NeetCode;

// Включает ли матрица переданный элемент
public class SearchA2DMatrix
{
    public static bool Include(int[][] matrix, int target)
    {
        var leftIndex = 0;
        var rightIndex = matrix.Length * matrix[0].Length-1;

        while (leftIndex <= rightIndex)
        {
            var mid =  leftIndex + (rightIndex - leftIndex) / 2;
            var column = mid / matrix.Length;
            var row = mid % matrix.Length;
            
            var value = matrix[column][row];

            if (value == target)
            {
                return true;
            }

            if (value < target)
            {
                leftIndex = mid+1;
            }
            else
            {
                rightIndex = mid - 1;
            }
        }

        return false;
    }
}