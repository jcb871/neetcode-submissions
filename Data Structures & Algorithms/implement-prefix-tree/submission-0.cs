public class PrefixTree {
    private class TrieNode {
        public TrieNode[] Children {get; private set; } = new TrieNode[26];
        public bool IsEndOfWord {get; set;}
    }

    private readonly TrieNode _root;

    public PrefixTree() {
        _root = new TrieNode();
    }
    
    public void Insert(string word) {
        TrieNode node = _root;
        foreach(char ch in word) {
            int index = ch - 'a';
            if(node.Children[index] == null) node.Children[index] = new TrieNode();
            node = node.Children[index];
        }
        node.IsEndOfWord = true;
    }
    
    public bool Search(string word) {
        return FindNode(word)?.IsEndOfWord ?? false;
    }
    
    public bool StartsWith(string prefix) {
        return FindNode(prefix) != null;
    }

    private TrieNode FindNode(string text) {        
        TrieNode node = _root;
        foreach(char ch in text) {
            int index = ch - 'a';
            if(node.Children[index] == null) return null;
            node = node.Children[index];
        }
        return node;
    }
}