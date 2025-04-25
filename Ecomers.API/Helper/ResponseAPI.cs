using Azure.Core;
using Microsoft.AspNetCore.Hosting.Server;
using System;

namespace Ecomers.API.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string? nessaae = null)
        {
            StatusCode = statusCode;
            Nessaae = nessaae?? GetmessageFornStatusCode(StatusCode );
        }

        private string GetmessageFornStatusCode(int statuscode)
        {
            return statuscode switch
            {
                200 => "Done",
                400 => "Bad Request",
                401 => "Un Author",
                500 => "server Eror",
                _ => null!
            };
        }
        public int StatusCode { get; set; }
        public string? Nessaae { get; set; }
    }
}
