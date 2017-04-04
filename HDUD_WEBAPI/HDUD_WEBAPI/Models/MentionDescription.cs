using System;
using System.Collections.Generic;

namespace HDUD_WEBAPI.Models
{
    public partial class MentionDescription
    {
        public int UserMentionId { get; set; }
        public string Description { get; set; }
        public int MentionId { get; set; }
        public byte? Rating { get; set; }
        public string Feel { get; set; }

        public virtual Mention Mention { get; set; }
    }
}
