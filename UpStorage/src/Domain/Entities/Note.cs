using Domain.Common;

namespace Domain.Entities
{
    public class Note:EntityBase<Guid>
    {
        public string? Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
