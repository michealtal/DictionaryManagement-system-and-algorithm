using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryManagement_system.Algorithm_Section
{
    public class dataOptimisation
    {
        public int FindTheMissingNumber(int[] nums)
        {
            int n = nums.Length;
            int expectedSum = n * (n + 1) / 2;
            int actualSum = 0;

            foreach (int num in nums)
            {
                actualSum += num;
            }
            int missingNumber = expectedSum - actualSum;

            return missingNumber;
        }

        public int[] NonZeroElements(int[] nums) // note this is to move numbes zero to the end of the array
        {
            int nonZeroIndex = 0;

            // shift all other of the nums to the front of the array
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[nonZeroIndex] = nums[i];
                    nonZeroIndex++;
                }
            }

            while(nonZeroIndex < nums.Length)
            {
                nums[nonZeroIndex] = 0;
                nonZeroIndex++;
            }
            return nums;
        }

        public int MostAppearedNum(int[] nums)
        {
            // Step 1: Create a dictionary to store each number and how many times it appears
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Step 2: Track which number has appeared most
            int mostSeenNum = nums[0];

            // Step 3: Loop through each number in the array
            foreach (int n in nums)
            {
                // If we’ve seen this number before, increase its count
                if (map.ContainsKey(n))
                {
                    map[n]++;
                }
                else
                {
                    // If it’s the first time seeing this number, set its count to 1
                    map[n] = 1;
                }

                // Step 4: Update 'mostSeenNum' if this number’s count is now higher
                if (map[n] > map[mostSeenNum])
                {
                    mostSeenNum = n;
                }
            }

            // Step 5: Return the number that appeared most
            return mostSeenNum;
        }


        public void MoveNegativesToFront(int[] nums)
        {
            int left = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[left];
                    nums[left] = temp;
                    left++;
                }
            }
        }

        public Dictionary<char, int> HowManyTimesCharAppered(string str)
        {
            Dictionary<char,int> charCount = new Dictionary<char,int>();
            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }
            return charCount;
        }

    }



};
