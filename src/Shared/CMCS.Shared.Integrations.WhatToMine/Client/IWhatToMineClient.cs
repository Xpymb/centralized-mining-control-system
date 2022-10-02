using CMCS.Shared.Integrations.WhatToMine.Models;

namespace CMCS.Shared.Integrations.WhatToMine.Client;

public interface IWhatToMineClient
{
    Task<Coin?> GetCoinInfoAsync(int coinId, CancellationToken token);
    Task<IEnumerable<Coin>> GetCoinsInfoAsync(IEnumerable<int> coinsId, CancellationToken token);
}