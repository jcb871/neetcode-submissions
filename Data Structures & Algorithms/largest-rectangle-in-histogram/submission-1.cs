public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int maxArea = 0;

        Stack<int> stack = []; //Used to keep track of monotonic heights
        for(int i=0; i<heights.Length || stack.Count > 0;i++) {
            int currHeight = i >= heights.Length ? 0 : heights[i];
            while(stack.Count > 0 && heights[stack.Peek()] >= currHeight) {
                int height = heights[stack.Pop()];
                int right = Math.Min(i, heights.Length);
                int left = stack.Count == 0 ? -1 : stack.Peek();
                int area = (right - left - 1) * height;
                if(maxArea < area) maxArea = area;
            }
            if(i < heights.Length) {
                stack.Push(i);
            }
        }

        return maxArea;
    }
}
