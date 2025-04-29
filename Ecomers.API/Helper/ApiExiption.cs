namespace Ecomers.API.Helper
{
    public class ApiExiption : ResponseAPI
    {
        public ApiExiption(int statusCode, string? nessaae = null , string detalis = null) : base(statusCode, nessaae)
        {
            
            Details = detalis;
        }
        public string Details { get; set; }
    }
}
