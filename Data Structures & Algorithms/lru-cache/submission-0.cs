public class LRUCache {
    public class ListNode {
        public int Key {get; set;}
        public int Val {get; set;}
        public ListNode Next {get; set;}
        public ListNode Prev {get; set;}
    }
    private readonly Dictionary<int, ListNode> _items;
    private readonly ListNode _first;
    private readonly ListNode _last;
    private int _capacity;
    public LRUCache(int capacity) {
        _capacity = capacity;
        _items = new Dictionary<int, ListNode>(capacity);
        _first = new ListNode();
        _last = new ListNode();
        _first.Next = _last;
        _last.Prev = _first;
    }
    
    public int Get(int key) {
        if(_items.TryGetValue(key, out ListNode item)) {
            MoveToRecent(key, item);
            return item.Val;
        }
        return -1;
    }
    
    public void Put(int key, int value) {        
        if(_items.TryGetValue(key, out ListNode item)) {
            MoveToRecent(key, item);
            item.Val = value;
            return;
        }
        else if(_items.Count == _capacity) {
            EvictLeastRecent();
        }
        ListNode newNode = new () {
            Key = key,
            Val = value
        };
        AddToRecent(key, newNode);
        _items[key] = newNode;
    }

    private void MoveToRecent(int key, ListNode node) {
        ListNode prev = node.Prev;
        ListNode next = node.Next;
        prev.Next = next;
        next.Prev = prev;
        AddToRecent(key, node);
    }

    private void AddToRecent(int key, ListNode newNode) {
        ListNode next = _first.Next;
        _first.Next = newNode;
        newNode.Prev = _first;
        newNode.Next = next;
        next.Prev = newNode;
    }

    private void EvictLeastRecent() {
        ListNode lruNode = _last.Prev;
        _items.Remove(lruNode.Key);
        ListNode prev = lruNode.Prev;
        prev.Next = _last;
        _last.Prev = prev;
    }
}
