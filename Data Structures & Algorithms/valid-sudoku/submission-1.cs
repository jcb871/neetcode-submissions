public class Solution {
    public bool IsValidSudoku(char[][] board) {
        int rows = board.Length;
        int cols = board[0].Length;
        // Console.WriteLine($"Rows:{rows}, Cols:{cols}");
        // //Validate Rows
        for(int r=0; r< rows; r++){
            if(!HasValidNumbers(board, r, 0, r+1, cols )) return false;
        }
        //Validate Cols
        for(int c=0; c< cols; c++){
            if(!HasValidNumbers(board, 0, c, rows, c+1 )) return false;
        }
        //Validate Squares
        // Console.WriteLine("Squares validation");
        for(int r=0; r< rows; r+=3){
            for(int c=0; c< cols; c+=3){
                if(!HasValidNumbers(board, r, c, r+3, c+3)) return false;
            }
        }
        return true;
    }

    private bool HasValidNumbers(char[][] board, int r1, int c1, int r2, int c2) {
        HashSet<char> nums = [];
        for(int r=r1; r<r2; r++){
            for(int c=c1; c<c2; c++){
                char current = board[r][c];
                if(current == '.') continue;
                if(!IsValidNumber(current) || nums.Contains(current)) return false;
                nums.Add(current);                
            }
        }
        return true;
    }

    private bool IsValidNumber(char c){
        return c > '0' && c <= '9';
    }
}
