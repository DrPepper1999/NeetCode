namespace NeetCode;

/// <summary>
/// You are given a a 9 x 9 Sudoku board board. A Sudoku board is valid if the following rules are
/// followed:
/// 1. Each row must contain the digits 1-9 without duplicates.
/// 2. Each column must contain the digits 1-9 without duplicates.
/// 3. Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without duplicates.
///
/// Return true if the Sudoku board is valid, otherwise return false
/// Note: A board does not need to be full or be solvable to be valid.
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