public class TimeMap {
    private Dictionary<string, List<(int time, string value)>> _data;
    public TimeMap() {
        _data = [];
    }
    
    public void Set(string key, string value, int timestamp) {
        if(!_data.TryGetValue(key, out List<(int time, string value)> values)) {
            values = [];
            _data[key] = values;
        }
        values.Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
        _ =_data.TryGetValue(key, out List<(int time, string value)> values);
        // return values?.LastOrDefault(v=>v.time <= timestamp).value;// || string.Empty;
        return FindRecentValueByTime(values, timestamp);
    }

    private string FindRecentValueByTime(List<(int time, string value)> values, int timestamp) {
        if(values == null || values.Count == 0) return string.Empty;
        int l=0, r=values.Count-1;
        string result = string.Empty;
        while(l <= r) {
            int m = l + (r-l) / 2;
            (int time, string value) mid = values[m];
            if(mid.time == timestamp) {
                result = mid.value;
                break;
            }
            if(mid.time > timestamp) {
                r = m-1;
            }
            else {                
                result = mid.value;
                l = m+1;
            }
        }
        return result;
    }
}
