using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Dto
{
    public class LikeDto
    {
        public int SafetyNewsId { get; set; }
        public string LikerId { get; set; }
    }
}