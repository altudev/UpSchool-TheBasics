namespace UpSchool.Domain.Utilities
{
    public interface IIPHelper
    {
        string GetCurrentIPAddress();

        List<string> GetAllIPAddresses();
    }
}
