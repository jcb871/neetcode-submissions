public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int maxFreq = 0;
        int maxFreqCount = 0;
        Dictionary<char, int> counts = [];
        foreach(char task in tasks) {
            if(!counts.TryGetValue(task, out int count)) {
                count = 0;
            }
            counts[task] = ++count;            
            if(maxFreq < count) {
                maxFreq = count;
                maxFreqCount = 1;
            }
            else if(maxFreq == count) {
                maxFreqCount++;
            }
        }
        int minTime = Math.Max((maxFreq-1)*(n+1) + maxFreqCount, tasks.Length);
        return minTime;
    }
}
