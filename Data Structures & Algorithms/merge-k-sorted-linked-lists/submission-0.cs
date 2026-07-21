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
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists == null || lists.Length == 0) return null;
        
        int interval = 1;
        while(lists.Length > interval) {
            for(int i=0; i + interval < lists.Length; i += interval*2) {
                lists[i] = Merge(lists[i], lists[i + interval]);
            }
            interval *= 2;
        }

        return lists[0];
        // List<ListNode> mergedLists = [];
        // for(int i=1; i < lists.Length; i+=2) {
        //     ListNode tempMerged = Merge(lists[i-1], lists[i]);
        //     mergedLists.Add(tempMerged);
        // }
        // if(lists.Length % 2 !=0) {
        //     mergedLists.Add(lists[lists.Length-1 ]);
        // }

        // return MergeKLists(mergedLists.ToArray());
    }

    private ListNode Merge(ListNode list1, ListNode list2) {
        ListNode merged = new();
        ListNode curr = merged;
        while(list1 != null && list2 != null) {
            if(list1.val > list2.val) {
                curr.next = list2;
                curr = list2;
                list2 = list2.next;
            }
            else{
                curr.next = list1;
                curr = list1;
                list1 = list1.next;
            }
        }
        curr.next = list1 ?? list2;
        return merged.next;
    }
}
