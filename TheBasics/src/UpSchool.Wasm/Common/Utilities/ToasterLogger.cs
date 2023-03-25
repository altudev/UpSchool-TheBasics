using Blazored.Toast.Services;
using UpSchool.Domain.Common;
using UpSchool.Domain.Services;

namespace UpSchool.Wasm.Common.Utilities
{
    public class ToasterLogger:LoggerBase
    {
        private readonly IToasterService _toasterService;

        public ToasterLogger(IToasterService toasterService, string apiUrl):base(apiUrl)
        {
            _toasterService = toasterService;
        }

        public override void Log(string message)
        {
            _toasterService.ShowSuccess(message);

            base.Log(message);
        }
    }
}
