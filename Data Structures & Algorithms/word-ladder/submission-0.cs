public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> wordSet = new(wordList);
        if(!wordSet.Contains(endWord)) return 0;

        Queue<string> q = new();
        q.Enqueue(beginWord);
        HashSet<string> visited = [beginWord];
        int level = 0;
        
        while(q.Count > 0) {
            int levelSize = q.Count;
            level++;
            for(int i=0; i< levelSize; i++) {
                string word = q.Dequeue();
                if(word == endWord) return level;
                foreach(string nextWord in wordList) {
                    if(!visited.Contains(nextWord) && CanTransform(word, nextWord)){
                        visited.Add(nextWord);
                        q.Enqueue(nextWord);
                    }
                }
            }
        }        
        return 0;
    }

    private bool CanTransform(string current, string target){
        if(current.Length != target.Length) return false;

        int dist = 0;
        for(int i=0; dist <= 1 && i<target.Length; i++) {
            if(current[i] != target[i]) dist++;
        }
        return dist == 1;
    }

    // private const int Visiting = 1;
    // private const int Visited = 2;
    // private int _min;
    // public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
    //     _min  = int.MaxValue;
    //     if(!wordList.Any(w => w == endWord)) return 0;
    //     wordList = wordList.Where(w => w.Length == endWord.Length).ToList();
    //     Dfs(beginWord, endWord, wordList, []);
    //     return _min == int.MaxValue ? 0 : _min;
    // }

    // private void Dfs(string word, string endWord, IList<string> wordList, Dictionary<string, int> visits) {
    //     if(word == endWord) {
    //         int count = 1 + visits.Count(kv=>kv.Value == Visiting);
    //         if(_min > count) _min = count;
    //         return;
    //     }
    //     visits[word] = Visiting;
    //     foreach(string nextWord in wordList) {
    //         if(visits.ContainsKey(nextWord) || !CanTransform(word, nextWord)) continue;
    //         Dfs(nextWord, endWord, wordList, visits);
    //     }
    //     visits[word] = Visited;
    // }
}
