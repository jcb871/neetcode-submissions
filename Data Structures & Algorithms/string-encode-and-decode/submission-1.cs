public class Solution {

    public string Encode(IList<string> strs) {
        if(strs == null || !strs.Any()) return null;
        return string.Join(",", strs.Select(s=>EncodeInternal(s)).ToArray());
    }

    public List<string> Decode(string s) {
        if(s == null) return [];
        if(string.IsNullOrEmpty(s)) return [string.Empty];
        return s.Split(",").Select(s=>DecodeInternal(s)).ToList();
   }

   private string EncodeInternal(string str){
    if(string.IsNullOrEmpty(str)) return string.Empty;
    return Convert.ToBase64String(Encoding.ASCII.GetBytes(str));
   }
   
   private string DecodeInternal(string str){
    if(string.IsNullOrEmpty(str)) return string.Empty;
    return Encoding.ASCII.GetString(Convert.FromBase64String(str));;
   }
}
