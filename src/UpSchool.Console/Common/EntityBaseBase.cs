namespace UpSchool.Console.Common
{
    public class EntityBaseBase : IEntityBase
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

      

        public string ModifiedByUserId { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }

        public string DeletedByUserId { get; set; }
        public DateTimeOffset DeletedOn { get; set; }
    }
}
