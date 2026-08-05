public class Solution {
    public bool Exist(char[][] board, string word) {
        int rows = board.Length;
        if(rows == 0 || word.Length == 0) return false;
        int cols = board[0].Length;

        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                if(Exist(board, word, charPos: 0, r, c)) return true;
            }
        }

        return false;
    }

    private bool Exist(char[][] board, string word, int charPos, int r, int c) {        
        if(charPos == word.Length) return true;

        int rows = board.Length;
        int cols = board[0].Length;

        if(r < 0 || c < 0 || r >= rows || c >= cols 
            || board[r][c] != word[charPos]) return false;

        char currChar = board[r][c];
        board[r][c] = '\0';
        
        charPos++;
        //up
        if(Exist(board, word, charPos, r-1, c)) return true;
        
        //left
        if(Exist(board, word, charPos, r, c-1)) return true;

        //down
        if(Exist(board, word, charPos, r+1, c)) return true;
        
        //right
        if(Exist(board, word, charPos, r, c+1)) return true;

        board[r][c] = currChar;

        return false;
    }
}
