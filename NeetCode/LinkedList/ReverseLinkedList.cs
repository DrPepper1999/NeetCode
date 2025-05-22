namespace NeetCode;

public class ReverseLinkedList
{
    public ListNode ReverseList(ListNode head) {
        ListNode prevNode = null;
        while (head != null) 
        {
            var t = new ListNode(head.Value);
            t.Next = prevNode;
            prevNode = t;
            
            head = head.Next;
        }
        
        return prevNode;
    }
}