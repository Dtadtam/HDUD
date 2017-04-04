using System;
using System.Collections.Generic;

namespace HDUD_WEBAPI.Models
{
    public partial class UserMention
    {
        public int UserMentionId { get; set; }
        public string Description { get; set; }
        public int MentionId { get; set; }
        public int UserId { get; set; }

        public virtual Mention Mention { get; set; }
        public virtual User User { get; set; }
    }
}
