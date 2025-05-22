namespace NeetCode;

/// <summary>
/// Вренуть все узлы с переденным типом
/// </summary>
public class GetNodesTask
{
    public static List<Node> GetNodes(Node tree, string type)
    {
        var result = new List<Node>();
        var stack = new Stack<Node>();
        var visited = new HashSet<Node>();
        
        stack.Push(tree);
        
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (!visited.Add(node))
            {
                continue;
            }

            if (node.Type == type)
            {
                result.Add(node);
            }

            for (var i = (node.Children.Count-1); i >= 0; i--)
            {
                stack.Push(node.Children[i]);
            }
        }
        
        return result;
    }
}
public record Node(string Type, List<Node> Children, int Value);