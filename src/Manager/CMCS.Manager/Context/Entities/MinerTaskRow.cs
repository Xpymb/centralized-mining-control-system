namespace CMCS.Manager.Context.Entities;

public class MinerTaskRow
{
    public Guid Id { get; }
    public string Config { get; set; }
    public string Miner { get; set; }
    public string CryptoCoin { get; set; }
    public string Algorithm { get; set; }
    public DateTimeOffset CreatedDate { get; }
    public DateTimeOffset LastUpdateDate { get; set; }

    public MinerTaskRow(
        Guid id,
        string config,
        string miner,
        string cryptoCoin,
        string algorithm,
        DateTimeOffset createdDate,
        DateTimeOffset lastUpdateDate)
    {
        Id = id;
        Config = config;
        Miner = miner;
        CryptoCoin = cryptoCoin;
        Algorithm = algorithm;
        CreatedDate = createdDate;
        LastUpdateDate = lastUpdateDate;
    }
}