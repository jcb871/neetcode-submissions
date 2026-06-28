public class MinStack {
    private Stack<int> _data;
    private Stack<int> _min;
    public MinStack() {
        _data = [];
        _min = [];
    }
    
    public void Push(int val) {
        int currentMin = val;
        if(!_min.TryPeek(out int min) || min >= currentMin) {
            _min.Push(val);
        }
        _data.Push(val);
    }
    
    public void Pop() {
        int min = _data.Peek();
        _data.Pop();        
        if(min == _min.Peek()){
            _min.Pop();
        }
    }
    
    public int Top() {
        return _data.Peek();
    }
    
    public int GetMin() {
        return _min.Count > 0 ? _min.Peek() : -1;
    }
}
