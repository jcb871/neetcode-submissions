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
    public void ReorderList(ListNode head) {
        int halfLen = (FindLen(head) + 1)/2;

        //split list after halfLen
        ListNode part1 = head;
        ListNode part2 = null;
        int position = 0;
        ListNode curr = head;
        while(curr != null) {
            position++;
            if(position == halfLen) {
                part2 = curr.next;
                curr.next = null;
                break;
            }
            curr = curr.next;
        }

        //Reverse part2;
        ListNode reversePart2 = Reverse(part2);

        //Stitch two lists
        curr = part1;
        while(reversePart2 != null) {
            var next = curr.next;
            curr.next = reversePart2;
            reversePart2 = reversePart2.next;
            curr.next.next = next;
            curr = next;
        }
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

    private int FindLen(ListNode head) {
        int n = 0;
        while(head != null) {
            n++;
            head = head.next;
        }
        return n;
    }
}
