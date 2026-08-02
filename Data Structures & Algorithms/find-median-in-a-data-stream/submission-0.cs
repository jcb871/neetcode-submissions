public class MedianFinder {
    private readonly PriorityQueue<int, int> _left; //maxHeap
    private readonly PriorityQueue<int, int> _right; //minHeap
    public MedianFinder() {
        _left = new();
        _right = new();
    }
    
    public void AddNum(int num) {
        if(_right.Count > 0 && _right.Peek() < num) {
            _right.Enqueue(num, num); //minHeap
        }
        else {
            _left.Enqueue(num, -num); //maxHeap
        }

        //Rebalance
        if(Math.Abs(_left.Count - _right.Count) > 1) {
            if(_left.Count > _right.Count) {
                int top = _left.Dequeue();
                _right.Enqueue(top, top); //minHeap
            }
            else {
                int top = _right.Dequeue();
                _left.Enqueue(top, -top); //maxHeap
            }
        }
    }
    
    public double FindMedian() {
        if(_left.Count == _right.Count) {
            return _left.Count == 0? 0.0 : ((_left.Peek() + _right.Peek())/2.0);
        }

        if(_left.Count > _right.Count) return _left.Peek();
        return _right.Peek();
    }
}
