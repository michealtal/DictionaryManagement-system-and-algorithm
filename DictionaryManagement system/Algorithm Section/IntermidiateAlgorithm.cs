using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryManagement_system.Algorithm_Section
{
    public class IntermidiateAlgorithm
    {
        public bool IsPalindrome(string word)
        {
            string cleanedWord = word.ToLower().Replace(" ", "");
            int left = 0;
            int right = cleanedWord.Length - 1;

            while (left < right)
            {
                if (cleanedWord[left] != cleanedWord[right])

                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public int[] MergeArraySort(int[] first, int[] second)
        {
            int[] mergedArray = new int[first.Length + second.Length];

            int i = 0, j = 0, k = 0;

            while (i < first.Length && j < second.Length)
            {
                if (first[i] < second[j])
                {
                    mergedArray[k] = first[i];
                    i++;
                }
                else
                {
                    mergedArray[k] = second[j];
                    j++;
                }
                k++;
            }
            while (i < first.Length)
            {
                mergedArray[k] = first[i];
                i++;
                k++;
            }
            while (j < second.Length)
            {
                mergedArray[k] = second[j];
                j++;
                k++;
            }
            return mergedArray;
        }

        public bool isValidParenthesis(string intake)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in intake)
            {
                if (c == '[' || c == '(' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char top = stack.Pop();

                    if (c == ')' && top != '(') return false;
                    if (c == '}' && top != '{') return false;
                    if (c == '[' && top != ']') return false;
                }
            }
            return stack.Count == 0;
        }

        public int MaxSubArraySum(int[] arr)
        {
            int maxSoFar = arr[0];
            int currentMax = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                // Either extend the current subarray or start a new one
                currentMax = Math.Max(arr[i], currentMax + arr[i]);

                // Update the maximum so far
                maxSoFar = Math.Max(maxSoFar, currentMax);
            }

            return maxSoFar;
        }

        public int FindMissingNum(int[] nums)
        {
            int n = nums.Length;
            int expectedSum = (n * (n + 1)) / 2;
            int actualSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                actualSum += nums[i];
            }
            return expectedSum - actualSum;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int Complement = target - nums[i];
                if (numMap.ContainsKey(Complement))
                {
                    return new int[] { numMap[Complement], i };
                }
                if (!numMap.ContainsKey(nums[i]))
                {
                    numMap.Add(nums[i], i);
                }
            }


            return new int[] { -1, -1 };
        }

        public int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == target)
                {
                    return mid;
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

        public int NoRepeteOfString(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int left = 0;
            int maxLength = 0;
           
            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];
                // If char seen before and still inside window, move left
                if (charCount.ContainsKey(currentChar) && charCount[currentChar] >= left)
                {
                    left = charCount[currentChar] + 1;
                }

                // Update last seen index
                charCount[currentChar] = right;

                // Update max length
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }
}

        

