public class Solution {
    public string Multiply(string num1, string num2) {
        if(num1.Length < num2.Length) return Multiply(num2, num1);
        int[] n1 = num1.Select(c=>c - '0').ToArray();
        int[] n2 = num2.Select(c=>c - '0').ToArray();

        int[] product = new int[n1.Length+n2.Length+1];
        int j = product.Length-1;
        for(int i=n2.Length-1; i>=0; i--, j--) {
            Multiply(n1, n2[i], product, j);
        }
        string result = string.Join("", product).TrimStart('0');
        return (result.Length == 0)? "0" : result;
    }

    private void Multiply(int[] num1, int num2, int[] product, int start) {
        int len = num1.Length;
        int carry = 0;     
        int j = start;   
        for(int i=len-1; i>=0 && j>=0; i--, j--) {
            int currProduct = carry + (num1[i] * num2) + product[j];
            product[j] = currProduct % 10;
            carry = currProduct / 10;
        }
        product[j] += carry;
    }
}   