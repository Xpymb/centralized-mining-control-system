namespace CMCS.Manager.Contract.Models;

public record MinerConfig(
    string Config,
    MinerType Miner,
    CryptoCoinType CryptoCoin,
    AlgorithmType Algorithm);