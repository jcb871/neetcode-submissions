public class Solution {
    private class TrieNode {
        public TrieNode[] Children { get; } = new TrieNode[26];
        public bool EndOfWord {get; set;}
    }

    private class Trie {
        public TrieNode Root { get; } = new();

        public void Insert(string word) {
            TrieNode node = Root;
            foreach(char ch in word) {
                int index = ch - 'a';
                if(node.Children[index] == null) node.Children[index] = new TrieNode();
                node = node.Children[index];
            }
            node.EndOfWord = true;
        }

        public TrieNode FindNode(string word) {
            TrieNode node = Root;
            foreach(char ch in word) {
                int index = ch - 'a';
                if(node.Children[index] == null) return null;
                node = node.Children[index];
            }
            return node;
        }
    }

    private readonly Trie _trie = new ();

    public List<string> FindWords(char[][] board, string[] words) {
        List<string> result = [];
        int rows = board.Length;
        if(rows == 0 || words.Length == 0) return result;
        int cols = board[0].Length;

        foreach(string word in words) {
            _trie.Insert(word);
        }

        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                Backtrack(board, row: r, col: c, _trie.Root, curr: [], result);
            }
        }
        return result;
    }

    private void Backtrack(char[][] board, int row, int col, TrieNode node, List<char> curr, List<string> result){        
        int rows = board.Length;
        if(rows == 0) return;
        int cols = board[0].Length;
        if(row < 0 || row >= rows || col < 0 || col >= cols || board[row][col] == '#') return;

        char currChar = board[row][col];
        int index = currChar - 'a';
        if(node.Children[index] == null) return;

        node = node.Children[index];

        curr.Add(currChar);
        if(node.EndOfWord) {
            result.Add(new string(curr.ToArray()));
            node.EndOfWord = false;
        }
        
        board[row][col] = '#';
        Backtrack(board, row-1, col, node, curr, result); //up
        Backtrack(board, row, col-1, node, curr, result); //left
        Backtrack(board, row, col+1, node, curr, result); //right
        Backtrack(board, row+1, col, node, curr, result); //down

        board[row][col] = currChar;
        curr.RemoveAt(curr.Count-1);
    }
}
