namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/93/linked-list/773/
/// </summary>
public class LinkedListCycle
{
    public bool HasCycle(ListNode head) {
        var fast = head;
        var slow = head;
        
        while(fast!=null && fast.Next != null) {
            fast = fast.Next.Next;
            slow = slow.Next;
            
            if (fast == slow) {
                return true;
            }
        }
        
        return false;
    }
}