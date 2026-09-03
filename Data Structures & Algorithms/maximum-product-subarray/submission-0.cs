public class Solution {
    private int _maxProduct;
    public int MaxProduct(int[] nums) {
        int n = nums.Length;
        if(n == 0) return 0;

        _maxProduct = nums[0];
        int currMax = nums[0], currMin=nums[0];
        for(int i=1; i<n; i++) {
            int prevMax = currMax;
            int prevMin = currMin;
            int num = nums[i];
            currMax =  Math.Max(prevMax*num, prevMin*num);
            currMin =  Math.Min(prevMin*num, prevMax*num);
            if(currMax < num) currMax = num;
            if(currMin > num) currMin = num;
            if(_maxProduct < currMax) _maxProduct = currMax;
        }

        return _maxProduct;
    }
}
