using SafetyBoard.Dto;

namespace SafetyBoard.Controllers.Api
{
    public class CommentDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public string UserId { get; set; }

        public PostingDto Posting { get; set; }

        public int PostingId { get; set; }

        public string @comment { get; set; }

     
    }
}