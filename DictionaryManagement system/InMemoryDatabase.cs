using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryManagement_system
{

   
    public class InMemoryDatabase
    {
        private Dictionary<string, Dictionary<string, int>> db = new();
        private Dictionary<string, Dictionary<string, int>> updateCounts = new();
        private Dictionary<string, string> lockedRecord = new();
        private Dictionary<string , Stack<userAction>> userHistory = new();


        private void saveAction(string username, userAction action)
        {
            if (!userHistory.ContainsKey(username))
            {
                userHistory[username] = new Stack<userAction>();

                userHistory[username].Push(action);
            }
        }
        public string SetorInc(string username, string key, string field, int value)

        {
            

            if (lockedRecord.ContainsKey(key) && lockedRecord[key] != username)
            {
                return "LOCKED";
            }

            // before modifying value
            int? prevValue = db.ContainsKey(key) &&  db[key].ContainsKey(field) ? db[key][field] : (int?)null;


            //after modifying value
            saveAction(username, new userAction
            {
                Operation = "SET",
                Key =  key, 
                Field = field,
                PreviousValue = prevValue,

            });



            if (!db.ContainsKey(key))
            {
                db[key] = new Dictionary<string, int>();
            }
           

            if (!db[key].ContainsKey(field))
            {
                db[key][field] = value;
            }
            else   
            {
                db[key][field] += value;
            }
            

            if (!updateCounts.ContainsKey(key) )
            {
                updateCounts[key] = new Dictionary<string, int>();
            }
          

            if (!updateCounts[key].ContainsKey(field))
            {
                updateCounts[key][field] = 0;
            }
          
            //now increment the field 
            updateCounts[key][field]++;  


            return db[key][field].ToString();

        }

        public string Get(string key, string field)
        {
            if (db.ContainsKey(key) && db[key].ContainsKey(field))
            {
                return db[key][field].ToString();
            }
            return "";
        }


        public string Delete(string username, string key, string field)
        {

             if (db[key].ContainsKey(field))
            {
                int prevValue = db[key][field];

                saveAction(username, new userAction
                {
                    Operation = "DELETE",
                       Key = key,
                       Field = field,
                       PreviousValue = prevValue
                });
            }
           
                if (db.ContainsKey(key))
                {

                    db[key].Remove(field);



                    if (db[key].Count == 0)
                    {

                        db.Remove(key);
                    }


                    return "true";



                }
                return "false";
           
        

        }


        
        public string GetUpdatedCount(string key , string field)
        {
            if (updateCounts.ContainsKey(key) && updateCounts[key].ContainsKey(field))

            {
                return updateCounts[key][field].ToString();
            }
            return " 0";
        }

        public string Lock (string username, string key)
        {
            if (!lockedRecord.ContainsKey(key))
            {
                lockedRecord[key] = username;
            }
            return "true";
        }
 
        public string Undo(string username)
        {
            if (!userHistory.ContainsKey(username) || userHistory[username].Count == 0)
            return "NO_ACTION";

            var lastAction  = userHistory[username].Pop();

            if (lastAction.Operation == "SET")
            {
                if (lastAction.PreviousValue == null)
                {
                    if (db.ContainsKey(lastAction.Key) && db[lastAction.Key].ContainsKey(lastAction.Field))
                    {
                        db[lastAction.Key].Remove(lastAction.Field);

                        // If the record is empty, remove the whole key
                        if (db[lastAction.Key].Count == 0)
                            db.Remove(lastAction.Key);
                    }
                }
                else
                {
                    if (!db.ContainsKey(lastAction.Key))
                        db[lastAction.Key] = new Dictionary<string, int>();

                    db[lastAction.Key][lastAction.Field] = lastAction.PreviousValue.Value;
                }
            }
            else if (lastAction.Operation == "DELETE")
            {
                if (!db.ContainsKey(lastAction.Key))
                {
                   db[lastAction.Key] = new Dictionary<string, int>();
                }
                db[lastAction.Key][lastAction.Field] = lastAction.PreviousValue.Value;
            }

            return "OK";
        }

        public string Logout(string user)
        {
            userHistory.Remove(user);

            // Remove locks owned by this user
            foreach (var key in lockedRecord.Where(kvp => kvp.Value == user).Select(kvp => kvp.Key).ToList())
            {
                lockedRecord.Remove(key);
            }

            return "true";
        }
    }
}
   
