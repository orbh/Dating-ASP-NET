//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Friends = new HashSet<Friend>();
            this.Friends1 = new HashSet<Friend>();
            this.FriendRequests = new HashSet<FriendRequest>();
            this.FriendRequests1 = new HashSet<FriendRequest>();
            this.Messages = new HashSet<Message>();
            this.Messages1 = new HashSet<Message>();
        }
    
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Visibility { get; set; }
        public string Picture { get; set; }
    
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Friend> Friends1 { get; set; }
        public virtual ICollection<FriendRequest> FriendRequests { get; set; }
        public virtual ICollection<FriendRequest> FriendRequests1 { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> Messages1 { get; set; }
    }
}
