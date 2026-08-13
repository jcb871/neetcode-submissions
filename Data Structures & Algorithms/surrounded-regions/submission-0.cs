public class Solution {
    public void Solve(char[][] board) {
        if(board == null || board.Length == 0 || board[0].Length == 0) return;
        int rows = board.Length;
        int cols = board[0].Length;

        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                if((r == 0 || c == 0 || r == rows-1 || c == cols-1) 
                    && board[r][c] == 'O') 
                        Dfs(board, r, c, rows, cols);
            }
        }

        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                if(board[r][c] == 'S') {
                    board[r][c] = 'O';
                }
                else if(board[r][c] == 'O') {
                    board[r][c] = 'X';
                }
            }
        }
    }

    private void Dfs(char[][] board, int row, int col, int rows, int cols) {
        if(row < 0 || col < 0 || row >= rows || col >= cols 
            || board[row][col] != 'O') return;

        board[row][col] = 'S'; //mark as safe/visited

        Dfs(board, row+1, col, rows, cols); //up
        Dfs(board, row-1, col, rows, cols); //down
        Dfs(board, row, col-1, rows, cols); //left
        Dfs(board, row, col+1, rows, cols); //right
    }
}