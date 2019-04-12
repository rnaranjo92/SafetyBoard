using SafetyBoard.Dto;
using System;

namespace SafetyBoard.Controllers.Api
{
    public class CommentDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public string UserId { get; private set; }

        public SafetyNewsDto SafetyNewsDto { get; set; }

        public int SafetyNewsId { get; set; }

        public string postComment { get; private set; }


        protected CommentDto()
        {

        }

        public CommentDto(int safetyNewsId, string postingComment, string userId)
        {
            if (safetyNewsId == null)
                throw new ArgumentNullException();

            SafetyNewsId = safetyNewsId;
            postComment = postingComment;
            UserId = userId;
        }
    }
}