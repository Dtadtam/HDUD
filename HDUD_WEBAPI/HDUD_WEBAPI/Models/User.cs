using System;
using System.Collections.Generic;

namespace HDUD_WEBAPI.Models
{
    public partial class User
    {
        public User()
        {
            UserFollowingId = new HashSet<UserFollowingId>();
            UserMention = new HashSet<UserMention>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserFollowingId> UserFollowingId { get; set; }
        public virtual ICollection<UserMention> UserMention { get; set; }
    }
}
