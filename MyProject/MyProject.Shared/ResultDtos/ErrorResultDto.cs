using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace MyProject.Shared.ResultDtos
{
    /// <summary>
    /// Used to return information about an error.
    /// </summary>
    [Serializable]
    public class ErrorResultDto
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// List of validation errors, as pairs of (key, errors)
        /// </summary>
        public Dictionary<string, List<string>> ValidationErrors { get; set; } = new Dictionary<string, List<string>>();

        // For deserialization of json
        private ErrorResultDto()
        {
        }

        public ErrorResultDto(string message)
        {
            Message = message;
        }

        public ErrorResultDto(string message, string details)
            : this(message)
        {
            Details = details;
        }

        public static ErrorResultDto CreateValidationError(List<ValidationErrorDto> validationErrors, IStringLocalizer localizer)
        {
            var result = new ErrorResultDto(localizer["ValidationErrorsMessage"]);

            foreach (var error in validationErrors)
            {
                result.AddError(error.Field, error.Message);
            }

            return result;
        }

        private void AddError(string field, string error)
        {
            var fieldErrors = ValidationErrors.ContainsKey(field) ? ValidationErrors[field] : null;
            if (fieldErrors == null)
            {
                ValidationErrors.Add(field, new List<string>() { error });
            }
            else if (!fieldErrors.Contains(error))
            {
                fieldErrors.Add(error);
            }
        }
    }
}
