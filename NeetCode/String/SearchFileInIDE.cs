namespace NeetCode;

/// <summary>
/// Содержуться ли буквы из s в fileName, в таком же порядке но с произвольной растановкой
///
/// input: s: ho, fileName: hello.txt
/// output true
/// </summary>
public class SearchFileInIDE
{
    public static bool IDESearch(string s, string filename)
    {
        var sIndex = 0;

        foreach (var fileSymbol in filename)
        {
            if (fileSymbol != s[sIndex])
            {
                continue;
            }

            if (sIndex == s.Length - 1)
            {
                return true;
            }
            
            sIndex++;
        }

        return false;
    }
}