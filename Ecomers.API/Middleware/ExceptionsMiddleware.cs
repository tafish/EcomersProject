using Ecomers.API.Helper;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ecomers.API.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment environment;
        private readonly IMemoryCache memoryCache;
        private readonly TimeSpan _retTimeWendo = TimeSpan.FromSeconds(30);
        public ExceptionsMiddleware(RequestDelegate next, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, IMemoryCache memoryCache)
        {
            _next = next;
            this.environment = environment;
            this.memoryCache = memoryCache;
        }
        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                if (IsRequestAlled(context)==false)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";
                    var respons = new ApiExiption
                        ((int)HttpStatusCode.TooManyRequests, "too many reqwest...ples try Agen");
                   await context.Response.WriteAsJsonAsync(respons);
                } 
                await _next(context);

            }
            catch (Exception ex)
            {

                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                        var response = environment.IsDevelopment() ?
                        new ApiExiption((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                      : new ApiExiption((int)HttpStatusCode.InternalServerError, ex.Message);
                        var json =JsonSerializer.Serialize(response);
                       await context.Response.WriteAsync(json);
            }
        }

        private bool IsRequestAlled(HttpContext context)
        {
            var ipAdres = context.Connection.RemoteIpAddress.ToString();
            var cachKey = $"Ret:{ipAdres}";
            var detaTime= DateTime.Now;
            var (TimeTemp, count) = memoryCache.GetOrCreate(cachKey, Entry =>
            {
                Entry.AbsoluteExpirationRelativeToNow = _retTimeWendo;
                return (TimeTemp: detaTime, count: 0);

            });
            if (detaTime-TimeTemp<_retTimeWendo)
            {
                if (count>=8)
                {
                    return false;
                }
                memoryCache.Set(cachKey, (TimeTemp, count + 1), _retTimeWendo);
            }
            else
            {
                memoryCache.Set(cachKey, (TimeTemp, count ), _retTimeWendo);
            }
            return true;
        }
    }
}
