namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/770/
/// </summary>
public class RotateImage
{
    public void Rotate(int[][] matrix)
    {
        // 1 меняем местами элементы треугольником
        for (var i = 0; i  < matrix.Length; i++)
        {
            for (var j = i+1; j < matrix.Length; j++)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }

        // 2. ревёрсим все строки
        foreach (var row in matrix)
        {
            Array.Reverse(row);
        }
    }
}