using Andromeda.Exe.DeviceConfiguration.Data.Models.Builder;
using System;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.App
{
    public partial class HttpErrorRecord
    {
        public sealed class Builder : EntityBuilderBase<HttpErrorRecord>
        {
            public Builder()
            {
                RequiredMethods.Add(nameof(AddHttpRequest));
                RequiredMethods.Add(nameof(AddProblemDetails));
            }

            public new HttpErrorRecord Build()
            {
                _obj.Created = DateTime.UtcNow;
                return base.Build();
            }

            public Builder AddHttpRequest(
                string method,
                string scheme,
                bool isHttps,
                string host,
                string path,
                string protocol,
                string? queryString = null,
                long? cLength = null,
                string? cType = null
            )
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(method);
                ArgumentException.ThrowIfNullOrWhiteSpace(scheme);
                ArgumentException.ThrowIfNullOrWhiteSpace(host);
                ArgumentException.ThrowIfNullOrWhiteSpace(path);
                ArgumentException.ThrowIfNullOrWhiteSpace(protocol);

                _obj.HttpRequestMethod = method;
                _obj.HttpRequestScheme = scheme;
                _obj.HttpRequestIsHttps = isHttps;
                _obj.HttpRequestHost = host;
                _obj.HttpRequestPath = path;
                _obj.HttpRequestQueryString = queryString;
                _obj.HttpRequestProtocol = protocol;
                _obj.HttpRequestContentLength = cLength;
                _obj.HttpRequestContentType = cType;

                MethodCalled();

                return this;
            }

            public Builder AddProblemDetails(
                string? type,
                string? title,
                int? status,
                string? detail,
                string? instance,
                string? errors,
                string? extensions
            )
            {
                _obj.Type = type;
                _obj.Title = title;
                _obj.Status = status;
                _obj.Detail = detail;
                _obj.Instance = instance;
                _obj.Errors = errors;
                _obj.Extensions = extensions;

                MethodCalled();

                return this;
            }

            protected override HttpErrorRecord CreateObj()
                => new();
        }
    }
}
