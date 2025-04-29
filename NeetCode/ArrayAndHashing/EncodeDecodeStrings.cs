using System.Text;

namespace NeetCode;

public class EncodeDecodeStrings
{
    private const char SeparatorSymbol = '#';
    public string Encode(IList<string> strs)
    {
        var result = new StringBuilder();
        
        foreach (var str in strs)
        {
            result.Append($"{str.Length}{SeparatorSymbol}{str}");
        }
    
        return result.ToString();
    }
    
    public List<string> Decode(string s)
    {
        var result = new List<string>();
        //2#aa3#bbb
        var i = 0;
        while (i < s.Length)
        {
            var j = i;
            while (s[j] != SeparatorSymbol)
            {
                j++;
            }

            var length = int.Parse(s.Substring(i, j-i));
            var str = s.Substring(i, length);
            result.Add(str);
            i = i + j + 1 + str.Length;
        }

        return result;
    }
}