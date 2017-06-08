using System;
using Microsoft.Extensions.Logging;

namespace NrgsCodingChallenge
{
    public static class LoggerExtensions
    {
        /// <summary>
        /// The key to the structured logging (and Scope): Follow the reference
        /// </summary>
        private const string CorrelationIdKey = "{CorrelationId}";

        /// <summary>
        /// Begins the correlation identifier scope.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="correlationId">The identifier.</param>
        /// <returns></returns>
        public static IDisposable BeginCorrelationIdScope(this ILogger logger, string correlationId)
        {
            return logger.BeginScope(CorrelationIdKey, correlationId);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static void Log(this ILogger logger, LogLevel logEvent, string format, Exception error = null, params object[] args)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            switch (logEvent)
            {
                case LogLevel.Debug:
                    logger.LogDebug(0, error, format, args);
                    break;
                case LogLevel.Information:
                    logger.LogInformation(0, error, format, args);
                    break;
                case LogLevel.Warning:
                    logger.LogWarning(0, error, format, args);
                    break;
                case LogLevel.Error:
                    logger.LogError(0, error, format, args);
                    break;
                case LogLevel.Critical:
                    logger.LogCritical(0, error, format, args);
                    break;
                case LogLevel.None:
                    break; // Not to write any message
                default:
                    throw new ArgumentOutOfRangeException(nameof(logEvent), logEvent, null);
            }
        }

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void LogError(this ILogger logger, Exception ex, string format, params object[] args)
        {
            logger.Log(LogLevel.Error, format, ex, args);
        }

        /// <summary>
        /// Logs a warning event.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void LogWarning(this ILogger logger, Exception ex, string format, params object[] args)
        {
            logger.Log(LogLevel.Warning, format, ex, args);
        }
    }

}