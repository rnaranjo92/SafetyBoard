using System;

namespace SafetyBoard.Dto
{
    public class SafetyNewsDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public DateTime DatePosted { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Comment { get; set; }
        public bool IsRemoved { get; set; }
    }
}