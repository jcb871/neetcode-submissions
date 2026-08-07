public class Solution {
    public List<List<string>> SolveNQueens(int n) {
        List<List<string>> result = [];
        Backtrack(n, row:0, [], [], [], new int[n], result);
        return result;
    }

    private void Backtrack(int n, int row
        , HashSet<int> hotCols, HashSet<int> hotLeftDiag, HashSet<int> hotRightDiag
        , int[] currCols, List<List<string>> result) {
        if(n == row) {
            List<string> ans = currCols
                .Select(col=>ToRowString(n, col))
                .ToList();
            result.Add(ans);
            return;
        }

        for(int c=0; c<n; c++) {
            if(hotCols.Contains(c)|| hotLeftDiag.Contains(row+c) || hotRightDiag.Contains(row-c)) continue;
            hotCols.Add(c);
            hotLeftDiag.Add(row+c);
            hotRightDiag.Add(row-c);
            currCols[row] = c;

            Backtrack(n, row+1, hotCols, hotLeftDiag, hotRightDiag, currCols, result);

            hotLeftDiag.Remove(row+c);
            hotRightDiag.Remove(row-c);
            hotCols.Remove(c);
        }
    }

    private string ToRowString(int n, int col) {
        char[] rowChars = new char[n];
        Array.Fill(rowChars, '.');
        rowChars[col] = 'Q';
        return new string(rowChars);
    }
}
