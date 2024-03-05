namespace Com.Data.Configration
{
    public static class ApplicationBuilderExtension
    {
        public static void ConfigrationExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

        }
    }
}
