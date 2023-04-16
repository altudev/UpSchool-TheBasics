namespace UpSchool.Domain.Utilities
{
    public static class SignalRMethodKeys
    {
        public static class Accounts
        {
            public static string Added => nameof(Added);
            public static string DeleteAsync => nameof(DeleteAsync);
            public static string Deleted => nameof(Deleted);
        }
    }
}
