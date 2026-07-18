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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode dummy = new (0);
        ListNode curr = dummy;
        int carry = 0;
        while(l1 != null || l2 != null) {
            int val1 = l1?.val ?? 0;
            int val2 = l2?.val ?? 0;
            int sum = (val1 + val2 + carry);
            int ansVal = sum % 10;
            curr.next = new ListNode(ansVal);
            curr = curr.next;
            carry = sum / 10;
            l1 = l1?.next;
            l2 = l2?.next;
        }
        if(carry > 0) curr.next = new ListNode(carry);
        return dummy.next;
    }
}
