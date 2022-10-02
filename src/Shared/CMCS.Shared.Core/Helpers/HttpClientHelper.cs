using System.Text.Json;

namespace CMCS.Shared.Core.Helpers;

public static class HttpClientHelper
{
    public static async Task<TResult?> GetAsync<TResult>(HttpClient client, Uri query, CancellationToken token)
    {
        var response = await client
            .GetAsync(query, cancellationToken: token)
            .ConfigureAwait(false);

        var result = await response
            .EnsureSuccessStatusCode()
            .Content
            .ReadAsStreamAsync(token)
            .ConfigureAwait(false);

        return await JsonSerializer
            .DeserializeAsync<TResult>(result, cancellationToken: token)
            .ConfigureAwait(false);
    }
}