using System.Net;

namespace Client.Helpers
{
    public class ApiResponseResult<TModel>
    {
        public HttpStatusCode StatusCode { get; set; }
        public TModel Data { get; set; }
    }
}
