using System;
using System.Net.Http;

namespace AdSetDesafio.Infrastructure.Exceptions
{
    public static class HandledError
    {
        public static InvalidOperationException InvalidOperation(string message)
            => new(message);

        public static AccessViolationException AccessViolation(string message)
            => new(message);

        public static ApplicationException Application(string message)
            => new(message);

        public static ArgumentNullException ArgumentNull(string message)
            => new(message);

        public static HttpRequestException HttpRequest(string message)
            => new HttpRequestException(message);
    }
}