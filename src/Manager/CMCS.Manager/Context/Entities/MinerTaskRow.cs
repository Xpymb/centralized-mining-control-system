namespace CMCS.Manager.Context.Entities;

public class MinerTaskRow
{
    public Guid Id { get; }
    public string Config { get; set; }
    public string Miner { get; set; }
    public string CryptoCoin { get; set; }
    public string Algorithm { get; set; }
    public DateTimeOffset CreatedDate { get; }

    public MinerTaskRow(
        string config,
        string miner,
        string cryptoCoin,
        string algorithm)
    {
        Id = Guid.NewGuid();
        Config = config;
        Miner = miner;
        CryptoCoin = cryptoCoin;
        Algorithm = algorithm;
        CreatedDate = DateTimeOffset.UtcNow;
    }
}