using System;
using System.ComponentModel.DataAnnotations;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.App
{
    public partial class HttpErrorRecord : EntityBase
    {
        private HttpErrorRecord() { }

        [Required]
        public DateTime Created { get; private set; }

        #region Request

        [Required]
        public string HttpRequestMethod { get; private set; } = null!;

        [Required]
        public string HttpRequestScheme { get; private set; } = null!;

        [Required]
        public bool HttpRequestIsHttps { get; private set; }

        [Required]
        public string HttpRequestHost { get; private set; } = null!;

        [Required]
        public string HttpRequestPath { get; private set; } = null!;

        public string? HttpRequestQueryString { get; private set; } = null!;

        [Required]
        public string HttpRequestProtocol { get; private set; } = null!;

        public long? HttpRequestContentLength { get; private set; }

        public string? HttpRequestContentType { get; private set; }

        #endregion

        #region ProblemDetails

        public string? Type { get; private set; }

        public string? Title { get; private set; }

        public int? Status { get; private set; }

        public string? Detail { get; private set; }

        public string? Instance { get; private set; }

        public string? Errors { get; private set; }

        public string? Extensions { get; private set; }

        #endregion
    }
}
