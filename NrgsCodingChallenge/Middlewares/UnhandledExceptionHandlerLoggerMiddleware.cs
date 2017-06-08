using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NrgsCodingChallenge.Middlewares
{
    /// <summary>
    /// Logs unhandled exception and returns 500
    /// </summary>
    internal class UnhandledExceptionHandlerLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly bool _includeStackTrace;
        private readonly ILogger<UnhandledExceptionHandlerLoggerMiddleware> _logger;

        public UnhandledExceptionHandlerLoggerMiddleware(
            RequestDelegate next,
            IHostingEnvironment environment,
            ILogger<UnhandledExceptionHandlerLoggerMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _includeStackTrace = true;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    // The user could be getting a 200 while there was a server error.
                    // Case where I see this happening is returning IEnumerable, so the Controller Action (see CurrencyController)
                    // returns and only at the time of yielding the result (deserialization) the error happens.
                    // When returning from the Action gracefully, it's assumed 200. At that stage it's too late
                    // to change the return type. This leaves us with 2 options: Yield to end always before returning so errors are found then.
                    // Or accept the fact that these errors won't be known by the user (receives 200 with empty response)
                    _logger.LogWarning("Response has started so status code won't be changed.");
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "text/plain";

                    if (_includeStackTrace)
                    {
                        var responseBody = ex.ToString();
                        context.Response.ContentLength = responseBody.Length;
                        await context.Response.WriteAsync(responseBody);
                    }
                }

                _logger.LogError(ex, "Unhandled Exception.");
            }
        }
    }
}