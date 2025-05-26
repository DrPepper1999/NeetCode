namespace NeetCode.Tree;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, int? left = null, int? right = null)
    {
        this.val = val;
        this.left = left.HasValue ? new TreeNode(left.Value) : null;
        this.right = right.HasValue ? new TreeNode(right.Value) : null;
    }
}

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/555/
/// Учитывая корень двоичного дерева, верните его глубину.
/// Глубина двоичного дерева определяется как количество узлов вдоль самого длинного пути от корневого узла до
/// самого дальнего листового узла.
/// </summary>
public class MaximumDepthOfBinaryTree
{
    public int MaxDepth(TreeNode root)
    {
        var result = 0;
        var stack = new Stack<(int depth, TreeNode node)>();
        stack.Push((1, root));
        
        while (stack.Count > 0)
        {
            var (depth, node) = stack.Pop();
            
            result = Math.Max(result, depth);
            
            stack.Push((depth+1, node.left));
            stack.Push((depth+1, node.right));
        }

        return result;
    }
}