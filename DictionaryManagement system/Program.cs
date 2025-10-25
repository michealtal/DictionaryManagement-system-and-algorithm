using System.Data;
using DictionaryManagement_system.Algorithm_Section;

namespace DictionaryManagement_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new InMemoryDatabase();
            List<string> result = new();
            result.Add(db.Lock("user1", "A"));
            result.Add(db.SetorInc("user1","A", "B", 4));
            result.Add(db.SetorInc("user1", "A", "B", 7));
            result.Add(db.SetorInc("user2","A", "C", 6));
            result.Add(db.Get("A", "C"));
            result.Add(db.Get("A", "B"));
            result.Add(db.Delete("user1", "A", "C"));
            result.Add(db.Delete("user1", "A", "B"));
            result.Add(db.GetUpdatedCount("A", "B"));
            result.Add(db.GetUpdatedCount("A", "C"));
            result.Add(db.Undo("user1"));
            result.Add(db.Get("A", "B"));
            result.Add(db.Logout("user1"));
           
            foreach (var r in result) {
                Console.WriteLine(r);
            }

        EasyAlgorithm sol = new EasyAlgorithm();

        int[] twoSumResult = sol.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
        Console.WriteLine(string.Join(", ", twoSumResult));

         int maxNum = sol.FindMaxNum(new int[] { 1, 3, 5, 9, 7 });
            Console.WriteLine(maxNum);

            int vowelCount = sol.CountVowels("Hello World");
            Console.WriteLine(vowelCount);

           int[] nums = { 1, 2, 2, 3, 4, 4, 5 };
            var (uniqueArray, count) = sol.RemoveDuplicates(nums);
            Console.WriteLine($"Unique Array: {string.Join(", ", uniqueArray)}, Count: {count}");

            string ReversedString = sol.ReverseString("Hello");
            Console.WriteLine(ReversedString);

            int GetTotal = sol.SumAllNum(new int[] { 1, 2, 3, 4,5});
            Console.WriteLine(GetTotal);

            IntermidiateAlgorithm ans = new IntermidiateAlgorithm();

            bool isPalindrome = ans.IsPalindrome("121");
            Console.WriteLine(isPalindrome);

            int[] mergedArray = ans.MergeArraySort(new int[] { 1, 3, 5 }, new int[] { 2, 4, 6,7,8 });
            Console.WriteLine(string.Join(", ", mergedArray));

            bool isValidParenthesis = ans.isValidParenthesis("() []");
            Console.WriteLine(isValidParenthesis);

            int[] num = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int MaxSubArraySum = ans.MaxSubArraySum(nums);
            Console.WriteLine(MaxSubArraySum);

            int[] number = { 0, 1, 2, 4, 5 };
            int FindMissingNum = ans.FindMissingNum(number);
            Console.WriteLine(FindMissingNum);

            int[] arr = { 5, 3, 8, 6, 2 };
            int[] TwoArrySums = ans.TwoSum(arr, 10);
            Console.WriteLine(string.Join(", ", TwoArrySums));

            int[] arr2 = { 2, 3, 5, 6, 8, 10, 14, 20 };
            int target = 10;

            int index = ans.BinarySearch(arr2, target);
            Console.WriteLine(index);  // Output: 5 (since arr[5] = 10) 

            string S = "abcdcdcd";
            int NoRepeteOfString = ans.NoRepeteOfString(S);
            Console.WriteLine(NoRepeteOfString);

            dataOptimisation dataOpt = new dataOptimisation();
            int missingNumber = dataOpt.FindTheMissingNumber(new int[] { 0, 1, 2, 4, 5 });
            Console.WriteLine(missingNumber);

            int[] ZeroNum = dataOpt.NonZeroElements(new int[] { 0, 1, 0, 3, 12 });
                Console.WriteLine(string.Join(", ", ZeroNum));

                int mostAppeared = dataOpt.MostAppearedNum(new int[] { 1, 3, 2, 3, 4, 3, 5, 1 });
                Console.WriteLine(mostAppeared);

            int[] numbers = { 3, -2, -1, 4, 0, -5 };
           dataOpt.MoveNegativesToFront(numbers);
            Console.WriteLine("Moved Negatives to Front: " + string.Join(", ", numbers));

            string word = "banana";
            Dictionary<char, int> Counts = dataOpt.HowManyTimesCharAppered(word);

            Console.WriteLine("Character counts:");
            foreach (var kvp in Counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            int[] Intersection =dataOpt.FindIntersection(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
            Console.WriteLine("Intersection: " + string.Join(", ", Intersection));
        }
    }
}
 