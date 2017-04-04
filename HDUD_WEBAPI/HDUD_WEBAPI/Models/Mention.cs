using System;
using System.Collections.Generic;

namespace HDUD_WEBAPI.Models
{
    public partial class Mention
    {
        public Mention()
        {
            MentionDescription = new HashSet<MentionDescription>();
            UserFollowingId = new HashSet<UserFollowingId>();
            UserMention = new HashSet<UserMention>();
        }

        public int MentionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MentionDescription> MentionDescription { get; set; }
        public virtual ICollection<UserFollowingId> UserFollowingId { get; set; }
        public virtual ICollection<UserMention> UserMention { get; set; }
    }
}
