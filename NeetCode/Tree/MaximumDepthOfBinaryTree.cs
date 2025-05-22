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
/// Given the root of a binary tree, return its depth.
/// The depth of a binary tree is defined as the number of nodes along the longest path from the root node down to the farthest leaf node.
/// </summary>
public class MaximumDepthOfBinaryTree
{
    public int MaxDepth(TreeNode root)
    {
        var result = 0;
        var visited = new HashSet<TreeNode>();
        var stack = new Stack<(int depth, TreeNode node)>();
        stack.Push((1, root));
        
        while (stack.Count > 0)
        {
            var (depth, node) = stack.Pop();

            if (!visited.Add(node))
            {
                continue;
            }

            result = Math.Max(result, depth);
            
            stack.Push((depth+1, node.left));
            stack.Push((depth+1, node.right));
        }

        return result;
    }
}