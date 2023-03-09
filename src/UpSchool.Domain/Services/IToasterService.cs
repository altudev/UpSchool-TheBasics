namespace UpSchool.Domain.Services
{
    public interface IToasterService
    {
        void ShowSuccess(string message);

        void ShowError(string message);
    }
}
