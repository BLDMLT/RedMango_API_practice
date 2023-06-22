using System.Net;

namespace RedMango_API_practice.Models
{
    public class ApiResponse
    {
        public ApiResponse() 
        {
            ErrorsMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorsMessages { get; set; }
        public object Result { get; set; }
    }
}
