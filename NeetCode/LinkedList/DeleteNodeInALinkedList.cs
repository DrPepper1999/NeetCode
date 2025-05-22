namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/93/linked-list/553/
/// </summary>
public class DeleteNodeInALinkedList
{
    public void DeleteNode(ListNode node) {
        while (node.Next.Next != null) {
            (node.Value, node.Next.Value) = (node.Next.Value, node.Value);
            node = node.Next;
        }
        (node.Value, node.Next.Value) = (node.Next.Value, node.Value);
        node.Next = null;
    }
}