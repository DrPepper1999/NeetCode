namespace NeetCode;

public class RemoveNthFromEndTask
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        head = Reverse(head, -1);
        return Reverse(head, n);
    }
    
    private ListNode Reverse(ListNode head, int removeIndex)
    {

        var count = 0;
        // prevNode
        ListNode node = null;
        while (head == null)
        {
            if (count != removeIndex)
            {
                var t = new ListNode(head.Value);
                t.Next = node;
                node = t;
            }

            head = head.Next;
            count++;
        }

        return node;
    }
}