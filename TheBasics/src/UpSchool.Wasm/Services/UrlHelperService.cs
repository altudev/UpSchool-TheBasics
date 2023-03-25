using UpSchool.Domain.Services;

namespace UpSchool.Wasm.Services
{
    public class UrlHelperService:IUrlHelperService
    {
        public string ApiUrl { get; }

        public UrlHelperService(string apiUrl)
        {
            ApiUrl = apiUrl;
        }
    }
}
