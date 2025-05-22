namespace NeetCode;

public class ListNode
{
    public int Value;
    public ListNode Next;

    public ListNode(int value = 0, ListNode next = null)
    {
        Value = value;
        Next = next;
    }
}

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/93/linked-list/771/discuss/2806932/Fastest-C-Solution
/// </summary>
public class MergeTwoSortedLinkedLists
{
    // [1 2 4] [1 3 4]
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 is null)
        {
            return list2;
        }

        if (list2 is null)
        {
            return list1;
        }

        var head = new ListNode();
        var nxt = head;

        while (list1 != null && list2 != null) 
        {
            if (list1.Value < list2.Value)
            {
                nxt.Next = list1;
                list1 = list1.Next;
            }
            else
            {
                nxt.Next = list2;
                list2 = list2.Next;
            }

            nxt = nxt.Next;
        }

        if (list2 == null)
        {
            nxt.Next = list1;
        }

        if (list1 == null)
        {
            nxt.Next = list2;
        }

        return head.Next;
    }
}