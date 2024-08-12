using Andromeda.Exe.DeviceConfiguration.Data.Models.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Andromeda.Exe.DeviceConfiguration.Server.DbContext.Extensions
{
    public static class HttpErrorRecordExtensions
    {
        public static HttpErrorRecord.Builder AddHttpRequest(
            this HttpErrorRecord.Builder builder,
            HttpRequest request
        ) => builder.AddHttpRequest(
            request.Method,
            request.Scheme,
            request.IsHttps,
            request.Host.ToString(),
            request.Path,
            request.Protocol,
            request.QueryString.Value,
            request.ContentLength,
            request.ContentType
        );

        public static HttpErrorRecord.Builder AddProblemDetails(
            this HttpErrorRecord.Builder builder,
            ProblemDetails problemDetails
        )
        {
            var errors = "{}";

            if (problemDetails is ValidationProblemDetails vpd)
            {
                errors = JsonSerializer.Serialize(vpd.Errors);
            }

            builder.AddProblemDetails(
                problemDetails.Type,
                problemDetails.Title,
                problemDetails.Status,
                problemDetails.Detail,
                problemDetails.Instance,
                errors,
                JsonSerializer.Serialize(problemDetails.Extensions)
            );

            return builder;
        }
    }
}
