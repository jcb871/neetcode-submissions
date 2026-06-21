public class Solution {
    public int[] ProductExceptSelf(int[] nums) {

        int[] result = new int[nums.Length];
        int rightProduct = 1;
        for(int i=nums.Length-1; i>= 0; i--){
            result[i] = rightProduct;
            rightProduct *= nums[i];            
        }

        int leftProduct = 1;
        for(int i=0; i<nums.Length; i++){
            result[i] = result[i] * leftProduct;
            leftProduct *= nums[i];
        }
        return result;
    }

    // private void FindProducts(int nums[], int[] result, int index =0, int left = 1) {
    //     if(index >= nums.Length) return;
    //     if(index == nums.Length - 1) {
    //         result[index] = left;
    //         return;
    //     }

    //     FindProducts(nums, result, index+1, left * nums[index]);

    //     result[index] = 
    // }
}
