using SafetyBoard.Dto;
using System;

namespace SafetyBoard.Controllers.Api
{
    public class CommentDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public string UserId { get; private set; }

        public PostingDto Posting { get; set; }

        public int PostingId { get; private set; }

        public string @comment { get; private set; }


        protected CommentDto()
        {

        }

        public CommentDto(int postingId, string postingComment, string userId)
        {
            if (postingId == null)
                throw new ArgumentNullException();

            PostingId = postingId;
            comment = postingComment;
            UserId = userId;
        }
    }
}