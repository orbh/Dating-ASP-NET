using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class FriendRepository
    {

        //Lägger till en vänskapskoppling 
        //i databasen mellan två valda användare
        public static void AcceptedRequest(User sender, User reciever)
        {
            var x = new Friend();
            x.UserID = reciever.ID;
            x.FriendID = sender.ID;

            var y = new Friend();
            y.UserID = sender.ID;
            y.FriendID = reciever.ID;

            using (var db = new DatingDatabaseEntities1())
            {
                db.Friends.Add(x);
                db.Friends.Add(y);
                db.SaveChanges();
            }
        }

        public static List<User> GetFriendsForUser(User user)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                List<Friend> friendList = db.Friends.Where(x => x.UserID == user.ID).ToList().ToList();
                List<User> convertedList = new List<User>();

                foreach (Friend friend in friendList)
                {
                    int id = Int32.Parse(friend.FriendID.ToString());
                    convertedList.Add(UserRepository.GetUserID(id));
                }
                return convertedList;
            }
        }

    }
}
