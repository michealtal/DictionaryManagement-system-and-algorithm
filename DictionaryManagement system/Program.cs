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
        }
    }
}
