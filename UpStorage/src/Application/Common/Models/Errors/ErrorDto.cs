namespace Application.Common.Models.Errors
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }
        public List<string> ErrorMessages { get; set; }

        public ErrorDto(string propertyName, List<string> errorMessages)
        {
            PropertyName = propertyName;

            ErrorMessages = errorMessages;
        }
    }
}
