public class Solution {
    private const int Visiting = 1;
    private const int Visited = 2;
    public string foreignDictionary(string[] words) {
        HashSet<int>[] adjList = new HashSet<int>[26];
        for(int i=0; i<26; i++) {
            adjList[i] = new HashSet<int>(26);
        }
        HashSet<int> letters = new (26);
        int n = words.Length;
        for(int i=0; i<n-1; i++) {
            string w1 = words[i];
            string w2 = words[i+1];
            foreach(char c in w1) letters.Add(c-'a');
            foreach(char c in w2) letters.Add(c-'a');
            if(w1.Length > w2.Length && w1.StartsWith(w2)) return string.Empty;
            int wLen = Math.Min(w1.Length, w2.Length);
            for(int w=0; w<wLen; w++) {                
                if(w1[w] == w2[w]) continue;
                int n1 = w1[w] - 'a';
                int n2 = w2[w] - 'a';
                adjList[n1].Add(n2);
                break;
            }
        }
        if(words.Length > 0) {
            foreach(char c in words[n-1]) letters.Add(c-'a');
        }

        List<int> result = new (letters.Count);
        int[] visit = new int[26];
        foreach(int letter in letters) {
            if(!Dfs(adjList, letter, visit, result)) return string.Empty;
        }

        return new string(result.Select(i=>(char)(i+'a')).Reverse().ToArray());
    }

    private bool Dfs(HashSet<int>[] adjList, int letter, int[] visit, List<int> result) {
        if(visit[letter] == Visiting) return false;
        if(visit[letter] == Visited) return true;

        visit[letter] = Visiting;

        HashSet<int> neigbors = adjList[letter];
        foreach(int nr in neigbors) {
            if(!Dfs(adjList, nr, visit, result)) return false;
        }

        visit[letter] = Visited;
        result.Add(letter);
        return true;
    }
}
