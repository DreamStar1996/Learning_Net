using System;
using System.Collections.Generic;

namespace User_Api.Models
{
    public partial class VoteData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int VoteId { get; set; }
        public string VoteName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
