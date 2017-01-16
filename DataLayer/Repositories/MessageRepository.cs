using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class MessageRepository
    {

       //Returnerar lista med meddelanden för specificerad användare
        public static List<string> GetMessages(string user)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                List<string> messageList = db.Messages.Where(x => x.User.UserName == user)
                    .Select(x => x.Message1).ToList();
                return messageList;
            }
        }

        //Läger till meddelande i databasen
        public static void AddMessage(Message msg)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                db.Messages.Add(msg);
                db.SaveChanges();
            }
        }

    }
}
