namespace Application.Core.Bases
{
    public class Response<T> : ResponseHandler
    {

        public Response()
        {

        }
        public Response(T data)
        {

            Data = data;
        }
        public Response(string message)
        {

            Message = message;
        }



        public T Data { get; set; }
        public string Message { get; set; }
    }
}
