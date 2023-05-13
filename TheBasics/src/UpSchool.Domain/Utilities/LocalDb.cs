namespace UpSchool.Domain.Utilities
{
    public class LocalDb:ILocalDB
    {
        public List<string> IPs { get; set; }

        public LocalDb()
        {
            IPs = new List<string>();
        }
    }
}
