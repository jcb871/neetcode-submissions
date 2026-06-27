public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new();
        Dictionary<char, char> opens = new () {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
        };
        bool isValid = false;
        foreach(char c in s) {
            if(opens.TryGetValue(c, out char close)) {
                stack.Push(close);
            }
            else if (!stack.Any() || stack.First() != c) {
                return isValid;
            }
            else {
                stack.Pop();
            }
        }
        isValid = !stack.Any();
        return isValid;
    }
}
