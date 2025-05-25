namespace NeetCode;

/// <summary>
/// Вам дают совет по правлению судоку 9 x 9. Совет по судоку действителен, если следующие правила
/// Следовал:
/// 1. Каждая строка должна содержать цифры 1-9 без дубликатов.
/// 2. Каждый столбец должен содержать цифры 1-9 без дубликатов.
/// 3. Каждый из девяти 3 x 3 подборов сетки должен содержать цифры 1-9 без дубликатов.
////
/// Вернуть True, если доска Sudoku действителен, в противном случае вернуть ложные
/// Примечание: доска не должна быть заполнена или быть разрешаемой, чтобы быть действительным.
/// </summary>
public class ValidSudoku
{
    public bool IsValidSudoku(char[][] board)
    {
        var rows = InitHashSets(board.Length);
        var cols = InitHashSets(board.Length);
        var squares = InitHashSets(board.Length);

        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board.Length; j++)
            {
                var item = board[i][j];

                if (item == '.')
                {
                    continue;
                }

                if (!rows[i].Add(item) || !cols[j].Add(item) || !squares[GetSquareIndex(i, j)].Add(item))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static HashSet<int>[] InitHashSets(int length)
    {
        var result = new HashSet<int>[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = new HashSet<int>();
        }

        return result;
    }

    private static int GetSquareIndex(int row, int col)
    {
        return (row / 3) * 3 + (col / 3);
    }
}