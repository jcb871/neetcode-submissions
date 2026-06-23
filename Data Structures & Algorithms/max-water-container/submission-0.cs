public class Solution {
    public int MaxArea(int[] heights) {
        int left =0, right = heights.Length-1;
        int maxVolume = 0;
        while(left<right) {
            int leftHeight = heights[left];
            int rightHeight = heights[right];
            int height;
            int width = right-left;
            if(leftHeight < rightHeight) {
                height = leftHeight;
                left++;
            }
            else {
                height = rightHeight;
                right--;
            }
            int volume = width * height;
            if(maxVolume<volume) maxVolume = volume;
        }
        return maxVolume;
    }
}
