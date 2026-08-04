public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        List<string> result = [];
        GenerateParenthesis(n, result, new StringBuilder());
        return result;
    }

    private void GenerateParenthesis(int n, List<string> result, StringBuilder current, int open = 0, int close = 0)
    {
        if(close == n) {
            result.Add(current.ToString());
            return;
        }

        if(open > close) {
            current.Append(")");
            GenerateParenthesis(n, result, current, open, close+1);
            current.Length--;
        }
        if(open < n) {
            current.Append("(");
            GenerateParenthesis(n, result, current, open+1, close);
            current.Length--;
        }
    }
}
