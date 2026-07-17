/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if(head == null) return null;
         Dictionary<Node, Node> nodes = [];
         Node newHead = new (0);
         Node old = head;
         Node copy = newHead;
         while(old != null) {
            if(!nodes.TryGetValue(old, out Node newNode)) {
                newNode = new Node(old.val);
                nodes[old] = newNode;
            }
            copy.next = newNode;
            copy = copy.next;
            old = old.next;
         }
         old = head;
         copy = newHead.next;         
         while(copy != null) {
            if(old.random != null) copy.random = nodes[old.random];
            copy = copy.next;
            old = old.next;
         }
         return newHead.next;
    }
}
