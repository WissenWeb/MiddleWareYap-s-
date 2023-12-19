namespace MiddleWareYapısı.Middleware
{
    public static class MiddlewareExtension
    {

        public static IApplicationBuilder UseHeaderChechMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeaderCheckerMiddleWare>();
        }
    }
}
