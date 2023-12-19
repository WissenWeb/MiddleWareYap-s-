using System.Text;

namespace MiddleWareYapısı.Middleware
{
    public class HeaderCheckerMiddleWare
    {

        private readonly RequestDelegate _next;
        public HeaderCheckerMiddleWare(RequestDelegate next)
        {
            _next = next;

        }

        public Task Invoke(HttpContext httpContext)
        {

            var clientId = httpContext.Request.Headers["ClientId"];
            var phoneNumber = httpContext.Request.Headers["PhoneNumber"];

            var body = httpContext.Request.Body;


            #region middleware içerisinde body'e erişip body içerisindeki nesneleri yakalama
            httpContext.Request.EnableBuffering();
            var bodyAsText =  new System.IO.StreamReader(httpContext.Request.Body).ReadToEndAsync();
            httpContext.Request.Body.Position = 0;

            #endregion


            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(phoneNumber))
            {
                httpContext.Response.StatusCode = 505;
                httpContext.Response.WriteAsync("Request Header Null");
            }
           

            return   _next.Invoke(httpContext);
        }
    }
}
