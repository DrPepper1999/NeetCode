namespace NeetCode;

public class MergeSortedLists
{
    public ListNode MergeLists(params ListNode[] listNodes)
    {
        if (listNodes.Length == 0) return null;

        var minHeap = new PriorityQueue<ListNode, int>();
        foreach (var list in listNodes) {
            if (list != null) {
                minHeap.Enqueue(list, list.Value);
            }
        }

        var res = new ListNode(0);
        var cur = res;
        while (minHeap.Count > 0) {
            var node = minHeap.Dequeue();
            cur.Next = node;
            cur = cur.Next;

            node = node.Next;
            if (node != null) {
                minHeap.Enqueue(node, node.Value);
            }
        }
        return res.Next;
    }
}