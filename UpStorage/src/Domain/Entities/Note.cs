using Domain.Common;

namespace Domain.Entities
{
    public class Note:EntityBase<Guid>
    {
        public string Name { get; set; }
    }
}
