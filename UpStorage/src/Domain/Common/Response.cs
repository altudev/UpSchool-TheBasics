namespace Domain.Common
{
    public class Response<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public Response()
        {
            
        }

        public Response(string message)
        {
            Message = message;
        }

        public Response(string message, T data)
        {
            Message = message;

            Data = data;
        }

        public Response(T data)
        {
            Data = data;
        }

        public Response(string message, T data, List<string> errors)
        {
            Message = message;

            Data = data;

            Errors = errors;
        }

        public Response(string message, List<string> errors)
        {
            Message = message;

            Errors = errors;
        }
    }
}
