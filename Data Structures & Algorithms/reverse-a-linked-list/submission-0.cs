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
    public ListNode ReverseList(ListNode head) {
        if(head == null) return head;

        ListNode curr = head;
        ListNode temp = null;
        while(curr != null) {
           var next = curr.next;
           curr.next = temp;
           temp = curr;
           curr = next;
        }
        return temp;
    }
}
