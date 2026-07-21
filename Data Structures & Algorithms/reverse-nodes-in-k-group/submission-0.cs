/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode result = new();
        ListNode curr = result;
        ListNode temp = head;
        while(temp != null){
            (ListNode p1, ListNode p2) = ReverseKGroupInternal(temp, k);
            curr.next = p1;
            while(curr.next != null) {
                curr = curr.next;
            }
            temp = p2;
        }
        return result.next;
    }

    private (ListNode p1, ListNode p2) ReverseKGroupInternal(ListNode head, int k) {
        (ListNode p1, ListNode p2, bool hasK) = SplitKNodes(head, k);
        if(hasK) p1 = Reverse(p1);
        return (p1, p2);
    }

    private ListNode Reverse(ListNode head) {
        ListNode curr = head;
        ListNode prev = null;
        while(curr != null) {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }

    private (ListNode p1, ListNode p2, bool hasK) SplitKNodes(ListNode head, int k) {
        int n = 0;
        ListNode p1 = head;
        ListNode prev = null;
        while(head != null && n < k) {
            n++;
            prev = head;
            head = head.next;
        }
        bool hasK = (n == k);
        ListNode p2 = head;
        if(hasK && prev != null) prev.next = null;
        return (p1, p2, hasK);
    }
}
