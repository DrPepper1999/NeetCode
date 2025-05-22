namespace NeetCode.Tree;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/631/
/// </summary>
public class ConvertSortedArrayToBinarySearchTree
{
    public TreeNode SortedArrayToBST(int[] nums) {
        return CreateTree(nums, 0, nums.Length-1);
    }
    
    private TreeNode CreateTree(int[] nums, int l, int r) {
        if (l > r) {
            return null;
        }
        
        var mid = (l + r) / 2;
        
        var root = new TreeNode(nums[mid]);
        root.left = CreateTree(nums, l, mid - 1);
        root.right = CreateTree(nums, mid+1, r);
        
        return root;
    }
}