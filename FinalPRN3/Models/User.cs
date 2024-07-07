using System;
using System.Collections.Generic;

namespace FinalPRN3.Models
{
    public partial class User
    {
        public User()
        {
            ChatroomUser1Navigations = new HashSet<Chatroom>();
            ChatroomUser2Navigations = new HashSet<Chatroom>();
            Contactgroups = new HashSet<Contactgroup>();
            FriendFriendNavigations = new HashSet<Friend>();
            FriendUsers = new HashSet<Friend>();
            Messages = new HashSet<Message>();
            Profiles = new HashSet<Profile>();
            Useractivities = new HashSet<Useractivity>();
            Usercontacts = new HashSet<Usercontact>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }

        public virtual Role? RoleNavigation { get; set; }
        public virtual ICollection<Chatroom> ChatroomUser1Navigations { get; set; }
        public virtual ICollection<Chatroom> ChatroomUser2Navigations { get; set; }
        public virtual ICollection<Contactgroup> Contactgroups { get; set; }
        public virtual ICollection<Friend> FriendFriendNavigations { get; set; }
        public virtual ICollection<Friend> FriendUsers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<Useractivity> Useractivities { get; set; }
        public virtual ICollection<Usercontact> Usercontacts { get; set; }
    }
}
