public class Solution {
    public List<int> PartitionLabels(string s) {
        int n = s.Length;
        List<char> letters = new(n);
        Dictionary<char, (int Start, int End)> ranges = new(n);
        for(int c=0; c<n; c++) {
            char letter = s[c];
            if(!ranges.TryGetValue(letter, out (int Start, int End) range)) {
                letters.Add(letter);
                ranges[letter] = (c, c);
            }
            else {
                ranges[letter] = (range.Start, c);
            }
        }

        List<int> result = new(n);
        (int Start, int End) prev = (0, -1);
        foreach(char letter in letters) {
            (int Start, int End) range = ranges[letter];

            if(prev.End > range.Start) {
                prev = (prev.Start, Math.Max(prev.End, range.End));
                continue;
            }

            if(prev.End != -1) {
                int count = (prev.End - prev.Start) + 1;
                result.Add(count);
            }
            prev = range;
        }

        if(prev.End >= 0) result.Add((prev.End - prev.Start) + 1);

        return result;
    }
}
