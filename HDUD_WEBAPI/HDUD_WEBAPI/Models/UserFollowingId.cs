using System;
using System.Collections.Generic;

namespace HDUD_WEBAPI.Models
{
    public partial class UserFollowingId
    {
        public int UserFollowingId1 { get; set; }
        public int UserId { get; set; }
        public int MentionId { get; set; }

        public virtual Mention Mention { get; set; }
        public virtual User User { get; set; }
    }
}
