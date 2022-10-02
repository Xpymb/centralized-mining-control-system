using System.Text.Json;
using CMCS.Shared.Core.Helpers;
using CMCS.Shared.Integrations.WhatToMine.Models;

namespace CMCS.Shared.Integrations.WhatToMine.Client;

public class WhatToMineClient : IWhatToMineClient
{
    private readonly HttpClient _client;

    public WhatToMineClient(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<CoinResponse?> GetCoinInfoAsync(int coinId, CancellationToken token)
    {
        return await HttpClientHelper.GetAsync<CoinResponse>(
                _client,
                new Uri($"/coins/{coinId}.json", UriKind.Relative), token)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<CoinResponse>> GetCoinsInfoAsync(IEnumerable<int> coinsId, CancellationToken token)
    {
        var result = new List<CoinResponse>();

        foreach (var coinId in coinsId)
        {
            var coin = await GetCoinInfoAsync(coinId, token);

            if (coin is null)
            {
                continue;
            }
            
            result.Add(coin);
        }

        return result;
    }
}