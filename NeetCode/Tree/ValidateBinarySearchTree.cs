namespace NeetCode.Tree;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/625/
/// Учитывая rootдвоичное дерево, определите, является ли оно допустимым двоичным деревом поиска (BST) 
/// </summary>
public class ValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root) {
        var stack = new Stack<(TreeNode, long, long)>();
        
        stack.Push((root, long.MinValue, long.MaxValue));
        
        while (stack.Count != 0) {
            var (node, left, right) = stack.Pop();
            
            if (node.val <= left || node.val >= right) {
                return false;
            }
            if (node.left != null) {
                stack.Push((node.left, left, node.val));
            }
            if (node.right != null) {
                stack.Push((node.right, node.val, right));
            }
        }
        
        return true;
    }
}