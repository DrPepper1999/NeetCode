namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/770/
/// Вам дано n x n 2D- matrix представление изображения, поверните изображение на 90 градусов (по часовой стрелке).
/// Вам нужно повернуть изображение на месте , что означает, что вам нужно напрямую изменить входную 2D-матрицу. НЕ выделяйте
/// другую 2D-матрицу и не делайте поворот.
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