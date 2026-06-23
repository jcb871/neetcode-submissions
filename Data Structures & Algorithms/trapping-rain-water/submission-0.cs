public class Solution {
    public int Trap(int[] height) {
        if(height.Length < 2) return 0;
        int[] left = new int[height.Length];
        int[] right = new int[height.Length];
        int max = 0;
        for(int i=1;i<height.Length;i++){
            left[i] = max = Math.Max(max, height[i-1]);
        }
        max = 0;
        for(int i=height.Length-2;i>=0;i--){
            right[i] = max = Math.Max(max, height[i+1]);
        }

        int rain = 0;
        for(int i=0;i<height.Length;i++){
            int maxHeight = Math.Min(left[i], right[i]);
            if(maxHeight > height[i]) rain += maxHeight - height[i];
        }
        return rain;
    }
}
