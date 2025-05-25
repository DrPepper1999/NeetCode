// See https://aka.ms/new-console-template for more information

using NeetCode;
using NeetCode.Lock;
using NeetCode.String;
using NeetCode.Tree;

var cach = new LRUCache(5);

cach.Put("1", "1");
cach.Put("2", "2");
cach.Put("3", "3");
cach.Put("4", "4");
cach.Put("5", "5");

cach.Get("1");
cach.Put("6", "6");


Console.WriteLine("sdsd");