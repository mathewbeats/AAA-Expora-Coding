using System;

int[] nums1 = new int[] {2, 4, 6, 8, 10};

int[] nums2 = new int[] {1, 3, 5, 7, 9};

int m = nums1.Length;
int n = nums2.Length;

var result = Solution.MergeTwoSortedArrays(nums1, m, nums2, n);

Console.WriteLine(string.Join(", ", result));




public class Solution 
{
    public static int[] MergeTwoSortedArrays(int[] nums1, int m, int[] nums2, int n)
    {
        if (nums1 == null) throw new ArgumentNullException(nameof(nums1));
        if (nums2 == null) throw new ArgumentNullException(nameof(nums2));
        if (m <= 0) throw new Exception("m cannot be lenght 0");
        if (n <= 0) throw new Exception("n cannot be length 0");


        int[] nums3 = new int[m + n];
        int i = 0;
        int j = 0;
        int k = 0;

        while (i < m && j < n)
        {
            if (nums1[i] <= nums2[j])
            {
                nums3[k] = nums1[i];
                i++;
                k++;
            }
            else
            {
                nums3[k] = nums2[j];
                j++;
                k++;
            }
        }

        while (i < m)
        {
            nums3[k] = nums1[i];
            i++;
            k++;
        }

        while (j < n)
        {
            nums3[k] = nums2[j];
            j++;
            k++;
        }

        return nums3;
    }
}