public class KthLargest {
    private readonly int _k;
    private readonly PriorityQueue<int, int> _nums;
    public KthLargest(int k, int[] nums) {
        _k = k;
        _nums = new(k);
        foreach(int num in nums) {
            Add(num);
        }
    }
    
    public int Add(int val) {
        if(_nums.Count < _k || _nums.Peek() < val) {
            if(_nums.Count == _k) _nums.Dequeue();
            _nums.Enqueue(val, val);
        }
        return _nums.Peek();
    }
}
