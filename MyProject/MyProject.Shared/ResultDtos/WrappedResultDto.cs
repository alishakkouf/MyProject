using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared.ResultDtos
{
    /// <summary>
    /// This class is used to create a wrapped result.
    /// </summary>
    [Serializable]
    public class WrappedResultDto
    {
        /// <summary>
        /// Indicates success status of the result.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The HTTP status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// The actual result object of request.
        /// It is set if <see cref="Success"/> is true.
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Error details (Must and only set if <see cref="Success"/> is false).
        /// </summary>
        public ErrorResultDto Error { get; set; }

        /// <summary>
        /// Creates an <see cref="WrappedResultDto"/> object with <see cref="StatusCode"/> specified.
        /// </summary>
        public WrappedResultDto(int statusCode)
        {
            StatusCode = statusCode;
            Success = 200 <= statusCode && statusCode <= 299;
        }

        /// <summary>
        /// Creates a <see cref="WrappedResultDto"/> object with <see cref="Result"/> specified,
        /// and specific <see cref="StatusCode"/> (by default 200)..
        /// <see cref="Success"/> is set as true.
        /// </summary>
        public WrappedResultDto(object result, int statusCode = 200)
        {
            StatusCode = statusCode;
            Result = result;
            Success = true;
        }

        /// <summary>
        /// Creates an <see cref="WrappedResultDto"/> object with <see cref="Error"/> specified,
        /// and specific <see cref="StatusCode"/> (by default 500).
        /// <see cref="Success"/> is set as false.
        /// </summary>
        public WrappedResultDto(ErrorResultDto error, int statusCode = 500)
        {
            Error = error;
            StatusCode = statusCode;
            Success = false;
        }
    }
}
