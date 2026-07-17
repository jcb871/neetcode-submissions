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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode result = new ();
        result.next = head;

        int pos = 0;
        ListNode curr = head;
        ListNode prev = result;
        while(curr != null) {
            curr = curr.next;
            if(pos >= n) {
                prev = prev.next;
            }
            pos++;
        }
        prev.next = prev.next.next;

        return result.next;
    }

    // public ListNode RemoveNthFromEnd(ListNode head, int n) {
    //     ListNode result = new ();
    //     result.next = head;

    //     int count = 0;
    //     ListNode curr = head;
    //     while(curr != null) {
    //         count++;
    //         curr = curr.next;
    //     }

    //     int delPosition = count - n;

    //     curr = head;
    //     ListNode prev = result;
    //     int p = 0;
    //     while(curr != null) {
    //         if(delPosition == p) {
    //             prev.next = curr.next;
    //             break;
    //         }
    //         prev = curr;
    //         curr = curr.next;
    //         p++;
    //     }

    //     return result.next;
    // }
}
