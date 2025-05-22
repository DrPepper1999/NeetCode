namespace NeetCode;

public class PalindromeLinkedListTask
{
    public bool IsPalindrome(ListNode head) {
        // find mid
        var fast = head;
        var slow = head;
        while (fast is not null && fast.Next != null) {
            fast = fast?.Next?.Next;
            slow = slow.Next;
        }
        
        // revert second half
        ListNode prev = null;
        while (slow != null) {
            var tmp = slow.Next;
            slow.Next = prev;
            prev = slow;
            slow = tmp;
        }
        
        
        // check palindrom
        var left = head;
        var right = prev;
        while (right != null) {
            if (left.Value != right.Value) {
                return false;
            }
            
            left = left.Next;
            right = right.Next;
        }
        
        return true;
    }
}