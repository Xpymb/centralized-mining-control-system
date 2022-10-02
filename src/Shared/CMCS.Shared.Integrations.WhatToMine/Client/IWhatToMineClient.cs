using CMCS.Shared.Integrations.WhatToMine.Models;

namespace CMCS.Shared.Integrations.WhatToMine.Client;

public interface IWhatToMineClient
{
    Task<CoinResponse?> GetCoinInfoAsync(int coinId, CancellationToken token);
    Task<IEnumerable<CoinResponse>> GetCoinsInfoAsync(IEnumerable<int> coinsId, CancellationToken token);
}