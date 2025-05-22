namespace NeetCode.Tree;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/628/
/// </summary>
public class BinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }
        var queue = new Queue<(TreeNode node, int depth)>();

        IList<IList<int>> result = [];
        
        queue.Enqueue((root, 1));

        var prevDepth = 0;
        while (queue.Count != 0)
        {
            var (node, depth) = queue.Dequeue();
            if (depth != prevDepth)
            {
                result.Add(new List<int>());
            }

            result[depth-1].Add(node.val);
            prevDepth = Math.Max(depth, prevDepth);

            if (node.left != null)
            {
                queue.Enqueue((node.left, depth + 1));
            }
            
            if (node.right != null)
            {
                queue.Enqueue((node.right, depth + 1));
            }
        }

        return result;
    }
}