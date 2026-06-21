public class Solution {
    public string Encode(IList<string> strs) {
        if(strs == null || strs.Count == 0) return string.Empty;
        StringBuilder encoded = new();
        foreach(string str in strs){
            int len = str.Length;
            encoded.Append(len.ToString("D3") + str);
        }
        return encoded.ToString();
    }

    public List<string> Decode(string s) {
        if(string.IsNullOrEmpty(s)) return [];
        Console.WriteLine("Encoded: " + s);
        List<string> strs = [];
        int index = 0;
        while(index <s.Length) {
            int len = Convert.ToInt16(s.Substring(index, 3));
            string word = s.Substring(index+3, len);
            strs.Add(word);
            index += 3 + len;
        }
        return strs;
   }
}
