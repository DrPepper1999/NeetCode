namespace NeetCode.Tree;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/627/
/// </summary>
public class SymmetricTree
{
    public bool IsSymmetric(TreeNode root) {
        return Dfs(root.left, root.right);
    }
    
    private bool Dfs(TreeNode left, TreeNode right) {
        if (left == null && right == null) {
            return true;
        }
        if (left == null || right == null) {
            return false;
        }
        
        return left.val == right.val && Dfs(left.left, right.right) && Dfs(left.right, right.left);
    }
}