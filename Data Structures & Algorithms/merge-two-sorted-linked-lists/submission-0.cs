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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode merged = new();
        ListNode mergedHead = merged;
        while(list1!=null && list2 != null) {
            if(list1.val <= list2.val) {
                merged.next = list1;
                list1 = list1.next;
            }
            else
            {
                merged.next = list2;
                list2 = list2.next;
            }
            merged = merged.next;
        }
        merged.next = list1 ?? list2;
        return mergedHead.next;
    }
}