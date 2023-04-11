using FluentValidation.Results;

using Serilog;
using Serilog.Core;

namespace ServiceNowComparerLibrary.Modules.Static
{
    /// <summary>
    /// Universal module to access the log
    /// </summary>
    public static class LogModule
    {
        private static readonly Logger _logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

        /// <summary>
        ///     Write a Message with Level "Information" to the Log.
        /// </summary>
        /// <param name="message">Your Message for the Log.</param>
        /// <returns></returns>
        public static void WriteInformation(string message) => _logger.Information(message);

        /// <summary>
        ///     Write a Message with Level "Error" to the Log.
        /// </summary>
        /// <param name="message">Your Message for the Log.</param>
        /// <returns></returns>
        public static void WriteError(string message) => _logger.Error(message);

        /// <summary>
        ///     Write a Message with Level "Debug" to the Log.
        /// </summary>
        /// <param name="message">Your Message for the Log.</param>
        /// <returns></returns>
        public static void WriteDebug(string message) => _logger.Debug(message);

        public static void ProcessValidationErrors(ValidationResult result)
        {
            if (result == null)
            {
                WriteError("Validationresults were empty");
                return;
            }
            for (int i = 0; i < result.Errors.Count; i++)
            {
                ValidationFailure failure = result.Errors[i];
                WriteError($"{failure.PropertyName}: {failure.ErrorMessage}");
            }
            return;

        }
    }
}