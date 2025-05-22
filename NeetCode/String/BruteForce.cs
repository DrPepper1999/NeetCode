using System.Text;

namespace NeetCode;

/// <summary>
/// Нужно подобрать пароль зная его хеш и функцию хеширования
/// Перебрать пароли
/// алфавит = ['a', 'b', 'c']
///             0    1    2
/// </summary>
public class BruteForce
{
    private readonly Dictionary<int, char> _alphabet = new()
    {
        { 0, 'a' },
        { 1, 'b' },
        { 2, 'c' }
    };

    public string Execute(string hashPassword)
    {
        for (var i = 0;; i++)
        {
            var password = GeneratePasswords(i, hashPassword.Length);

            if (DummyHash(password) == hashPassword)
            {
                return password;
            }
        }
    }

    private string GeneratePasswords(int n, int passwordLength)
    {
        if (n < _alphabet.Count)
        {
            return _alphabet[n].ToString();
        }
        
        var result = "";
        
        while (n > 0)
        {
            result += _alphabet[n % _alphabet.Count];
            n /= _alphabet.Count;
        }

        if (result.Length < passwordLength)
        {
            result = new string(_alphabet[0], passwordLength - result.Length) + result;
        }
        
        return result;
    }
    

    private static string DummyHash(string str)
    {
        return str;
    }
}