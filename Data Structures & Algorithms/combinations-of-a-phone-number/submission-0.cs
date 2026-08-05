public class Solution {
    private static readonly Dictionary<char, List<char>> _dictionary = new() {
        {'2', ['a', 'b', 'c']},
        {'3', ['d', 'e', 'f']},
        {'4', ['g', 'h', 'i']},
        {'5', ['j', 'k', 'l']},
        {'6', ['m', 'n', 'o']},
        {'7', ['p', 'q', 'r', 's']},
        {'8', ['t', 'u', 'v']},
        {'9', ['w', 'x', 'y', 'z']}
    };
    public List<string> LetterCombinations(string digits) {
        List<string> result = [];
        if(digits.Length > 0) {
            Backtrack(digits, position: 0, new StringBuilder(), result);
        }
        return result;
    }

    private void Backtrack(string digits, int position, StringBuilder current, List<string> result) {
        if(position == digits.Length) {
            if(current.Length == position) result.Add(current.ToString());
            return;
        }

        char digit = digits[position];
        if(!_dictionary.TryGetValue(digit, out List<char> chars)) {
            throw new ArgumentException();
        }

        foreach(char ch in chars) {
            current.Append(ch);
            Backtrack(digits, position+1, current, result);
            current.Length--;
        }
    }
}
