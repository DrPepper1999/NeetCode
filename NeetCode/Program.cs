// See https://aka.ms/new-console-template for more information

using NeetCode;
using NeetCode.String;
using NeetCode.Tree;

 bool IsAnagram(string s, string t) {
    var sDic = CreateFrenqencyDic(s);
    var tDic = CreateFrenqencyDic(t);
        
    return tDic.All(keyVal => {
        if (sDic.TryGetValue(keyVal.Key, out var value) && value > 0) {
            tDic[keyVal.Key]--;
            return true;
        }
            
        return false;
    });
}
    
 Dictionary<char, int> CreateFrenqencyDic(string str) {
    var result = new Dictionary<char, int>();
        
    foreach(var c in str) {
        if (!result.TryAdd(c, 1)) {
            result[c]++;
        }
    }
        
    return result;
}