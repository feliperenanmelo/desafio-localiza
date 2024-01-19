using Localiza.Veiculos.Api.Response;
using System.Net;

namespace Localiza.Veiculos.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Logar
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(new ResponseRequest((int)HttpStatusCode.InternalServerError, false, null, new[] { "Ocorreu um erro inesperado, por favor conte o administrador do sistema ou tente mais tarde" }));
            }
        }        
    }
}
