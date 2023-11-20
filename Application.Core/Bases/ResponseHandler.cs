namespace Application.Core.Bases
{
    public class ResponseHandler
    {

        public ResponseHandler()
        {

        }
        public Response<T> Deleted<T>(string Message = null)
        {
            return new Response<T>()
            {

                Message = "Deleted Successfully"
            };
        }
        public Response<T> Success<T>(T entity)
        {
            return new Response<T>()
            {
                Data = entity,


            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {

                Message = "UnAuthorized"
            };
        }
        public Response<T> BadRequest<T>(string Message)
        {
            return new Response<T>()
            {

                Message = Message == null ? "Bad Request" : Message
            };
        }

        public Response<T> NotFound<T>(string Message = null)
        {

            return new Response<T>()
            {

                Message = Message == null ? "Not Found" : Message
            };
        }

        public Response<T> Created<T>(T entity)
        {
            return new Response<T>()
            {
                Data = entity,
                Message = "Added Successfully",

            };

        }

    }
}
