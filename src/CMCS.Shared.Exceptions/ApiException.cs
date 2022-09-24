namespace CMCS.Shared.Exceptions;

public class ApiException : Exception
{
    public ApiException(
        string message,
        int statusCode,
        string? response,
        IReadOnlyDictionary<string, IEnumerable<string>>
            headers,
        Exception innerException)
        : base(
            message
            + "\n\nStatus: "
            + statusCode
            + "\nResponse: \n"
            + (response == null ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)),
            innerException)
    {
        StatusCode = statusCode;
        Response = response;
        Headers = headers;
    }

    public int StatusCode { get; }

    public string? Response { get; }

    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; }

    public override string ToString()
    {
        return $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
    }
}

public class ApiException<TResult> : ApiException
{
    public ApiException(
        string message,
        int statusCode,
        string response,
        IReadOnlyDictionary<string, IEnumerable<string>>
            headers,
        TResult result,
        Exception innerException)
        : base(
            message,
            statusCode,
            response,
            headers,
            innerException)
    {
        Result = result;
    }

    public TResult Result { get; }
}