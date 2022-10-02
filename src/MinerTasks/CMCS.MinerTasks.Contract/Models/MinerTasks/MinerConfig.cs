using CMCS.Shared.Core.Models;

namespace CMCS.MinerTasks.Contract.Models.MinerTasks;

public record MinerConfig(
    string Config,
    MinerType Miner,
    CryptoCoinType CryptoCoin,
    AlgorithmType Algorithm);