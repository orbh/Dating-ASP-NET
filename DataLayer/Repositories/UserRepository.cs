using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository
    {

        //Returnerar en user utifrån namn
        public static User GetUser(string name)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                User user = db.Users.FirstOrDefault(x => x.UserName == name);
                return user;
            }
        }

        //Returnerar en user ifrån ID
        public static User GetUserFromId(int user)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                User usr = db.Users.FirstOrDefault(x => x.ID == user);
                return usr;
            }
        }

        //Registrerar en ny användare
        public static void RegisterUser(User user)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        //Uppdaterar specificerad user (Kanske bör vara med ID istället)
        public static void UpdateUser(User nUser, string username)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                User oUser = db.Users.FirstOrDefault(x => x.UserName == username);
                oUser.Age = nUser.Age;
                oUser.Email = nUser.Email;
                oUser.FirstName = nUser.FirstName;
                oUser.Gender = nUser.Gender;
                oUser.LastName = nUser.LastName;
                oUser.Password = nUser.Password;
                oUser.UserName = nUser.UserName;
                oUser.Visibility = nUser.Visibility;
                db.SaveChanges();
            }
        }

        //Returnerar user som matchar användarnamn och lösenord
        public static User Login(string username, string pw)
        {
            using (var db = new DatingDatabaseEntities1())
            {
                return db.Users.FirstOrDefault(p => p.UserName.Equals(username)
                    && p.Password.Equals(pw));
            }
        }

        //Returnerar en lista av användare som matchar användarnamn, förnamn eller efternamn
        public static List<User> SearchForUser(string searchWord)
        {
            List<User> list = new List<User>();
            using (var db = new DatingDatabaseEntities1())
            {
                IEnumerable<User> matches = from user in db.Users
                                            where user.UserName.Contains(searchWord) ||
                                            user.FirstName.Contains(searchWord) ||
                                            user.LastName.Contains(searchWord)
                                            select user;
                return list = matches.ToList();
            }
        }

        //Returnerar slumpmässigt fram specificerat antal användare
        public static List<User> GetRandomUsers(int number)
        {
            try
            {
                using (var db = new DatingDatabaseEntities1())
                {
                    var result = db.Users
                        .OrderBy(x => Guid.NewGuid())
                        .Take(number)
                        .ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return new List<User>();
            }
        }

    }
}
