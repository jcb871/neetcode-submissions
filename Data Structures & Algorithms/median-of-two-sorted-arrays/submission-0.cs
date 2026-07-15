public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if(nums1.Length > nums2.Length) return FindMedianSortedArrays(nums2, nums1);

        int count = nums1.Length + nums2.Length;
        int leftCount = count / 2; 
        int l = 0, r = nums1.Length;
        while(l <= r) {
            int m = l + (r-l)/2;
            int m2 = (leftCount - m);
            int left1 = (m <= 0)? int.MinValue : nums1[m-1];
            int right1 = (nums1.Length > m)? nums1[m] : int.MaxValue;
            int left2 = (m2 <= 0)? int.MinValue : nums2[m2-1];
            int right2 = (nums2.Length > m2)? nums2[m2] : int.MaxValue;

            if(left1 <= right2 && left2 <= right2) {
                double median;
                if(count % 2 == 0) {
                    median = ((double)Math.Max(left1, left2) + (double)Math.Min(right1, right2))/2;
                }
                else {
                    median =  Math.Min(right1, right2);
                }
                return median;
            }
            else if(left1 > right2) {
                r = m-1;
            }
            else if(right1 > left2) {
                l = m+1;
            }
        }
        return 0;
    }
}
