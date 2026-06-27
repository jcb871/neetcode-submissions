public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new();
        Dictionary<char, char> opens = new () {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
        };
        foreach(char c in s) {
            if(opens.TryGetValue(c, out char close)) {
                stack.Push(close);
            }
            else if (stack.Count == 0 || stack.Peek() != c) {
                return false;
            }
            else {
                stack.Pop();
            }
        }
        
        return stack.Count == 0;
    }
}
