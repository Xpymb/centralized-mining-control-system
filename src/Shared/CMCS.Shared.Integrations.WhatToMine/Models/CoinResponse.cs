using System.Text.Json.Serialization;

namespace CMCS.Shared.Integrations.WhatToMine.Models;

public class CoinResponse
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("tag")]
    public string Tag { get; init; }
    
    [JsonPropertyName("algorithm")]
    public string Algorithm { get; init; }
    
    [JsonPropertyName("block_time")]
    public string BlockTime { get; init; }

    [JsonPropertyName("block_reward")]
    public double BlockReward { get; init; }
    
    [JsonPropertyName("block_reward24")]
    public double BlockReward24 { get; init; }
    
    [JsonPropertyName("block_reward3")]
    public double BlockReward3 { get; init; }
    
    [JsonPropertyName("block_reward7")]
    public double BlockReward7 { get; init; }
    
    [JsonPropertyName("last_block")]
    public long LastBlock { get; init; }
    
    [JsonPropertyName("difficulty")]
    public long Difficulty { get; init; }
    
    [JsonPropertyName("difficulty24")]
    public double Difficulty24 { get; init; }
    
    [JsonPropertyName("difficulty3")]
    public double Difficulty3 { get; init; }
    
    [JsonPropertyName("difficulty7")]
    public double Difficulty7 { get; init; }
    
    [JsonPropertyName("nethash")]
    public long Nethash { get; init; }
    
    [JsonPropertyName("exchange_rate")]
    public double ExchangeRate { get; init; }
    
    [JsonPropertyName("exchange_rate24")]
    public double ExchangeRate24 { get; init; }
    
    [JsonPropertyName("exchange_rate3")]
    public double ExchangeRate3 { get; init; }
    
    [JsonPropertyName("exchange_rate7")]
    public double ExchangeRate7 { get; init; }
    
    [JsonPropertyName("exchange_rate_vol")]
    public double ExchangeRateVol { get; init; }

    [JsonPropertyName("exchange_rate_curr")]
    public string ExchangeRateCurr { get; init; }
    
    [JsonPropertyName("market_cap")]
    public string MarketCap { get; init; }
    
    [JsonPropertyName("pool_fee")]
    public string PoolFee { get; init; }
    
    [JsonPropertyName("estimated_rewards")]
    public string EstimatedRewards { get; init; }
    
    [JsonPropertyName("btc_revenue")]
    public string BtcRevenue { get; init; }
    
    [JsonPropertyName("revenue")]
    public string Revenue { get; init; }
    
    [JsonPropertyName("cost")]
    public string Cost { get; init; }
    
    [JsonPropertyName("profit")]
    public string Profit { get; init; }
    
    [JsonPropertyName("status")]
    public string Status { get; init; }
    
    [JsonPropertyName("lagging")]
    public bool Lagging { get; init; }
    
    [JsonPropertyName("testing")]
    public bool Testing { get; init; }
    
    [JsonPropertyName("listed")]
    public bool Listed { get; init; }
    
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; init; }
}