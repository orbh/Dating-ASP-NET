using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class FriendRequestRepository
    {

        public static void SendFriendRequest(User sender, User reciever)
        {
            var request = new FriendRequest();
            request.RecieverID = reciever.ID;
            request.SenderID = sender.ID;
            request.Pending = "Friend request pending";

            using (var db = new DatingDatabaseEntities1())
            {
                db.FriendRequests.Add(request);
                db.SaveChanges();
            }
        }

        public static List<User> GetFriendRequests(User user)
        {
            var userIdList = new List<User>();
            using (var db = new DatingDatabaseEntities1())
            {
                var friendRequestList = from dbFriendRequest in db.FriendRequests
                                        where dbFriendRequest.SenderID == user.ID
                                        select dbFriendRequest.RecieverID;

                foreach (var item in friendRequestList)
                {
                    userIdList.Add(UserRepository.GetUserFromId(item));
                }
            }
            return userIdList;
        }

        public static void RemoveRequest(User sender, User reciever)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                var f = db.FriendRequests.FirstOrDefault(x => x.RecieverID == reciever.ID
                    && x.SenderID == sender.ID);
                db.FriendRequests.Remove(f);
                db.SaveChanges();
            }
        }

    }
}
