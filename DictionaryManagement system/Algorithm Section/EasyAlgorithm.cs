using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryManagement_system.Algorithm_Section
{
    public class EasyAlgorithm
    {
        public int[] TwoSum(int[] nums, int target)
        {
            // to avoid excess lopping and to make calculation easy
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }
            return new int[] { };
        }

        public int FindMaxNum(int[] input) 
        {
            int holding = input[0];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > holding)
                {
                    holding = input[i];
                }
            }
            return holding;
        }

        public int CountVowels(string input)
        {
            int count = 0;
            string vowels = "aeiou";
            string lowerInput = input.ToLower();
            foreach(char c in lowerInput)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }

        public (int[] uniqueArray, int count) RemoveDuplicates(int[] nums)
        {
            HashSet<int> uniqueNumbers = new HashSet<int>();

            foreach (int num in nums)
            {
                uniqueNumbers.Add(num);
            }

            int[] resultArray = uniqueNumbers.ToArray();
            int count = resultArray.Length;

            return (resultArray, count);
        }

        public string ReverseString(string word)
        {
            string reversed = "";

            for (int i = word.Length -1; i >= 0; i--)
            {
                reversed += word[i];
            }
            return reversed;
        }

        public int SumAllNum(int[] num)
        {
         int total = 0;
            foreach (int n in num)
            {
                total += n;
            }
            return total;
        }

        // this is if we want to use the inbuilt sum function 
    //    using System.Linq; // Required for Sum()

    //   public int SumAllNum(int[] num)
    //{
    //    return num.Sum();
    //}

}
}
