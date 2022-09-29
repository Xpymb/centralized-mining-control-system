namespace CMCS.Manager.Context.Entities;

public class NodeRow
{
    public Guid Id { get; }
    public string Name { get; }
    public string MiningStatus { get; set; }
    public string CurrentMiner { get; set; }
    public decimal CurrentHashrate { get; set; }
    public decimal CurrentTemperature { get; set; }
    public DateTimeOffset CreatedDate { get; }
    public DateTimeOffset LastUpdateDate { get; set; }

    public NodeRow(
        Guid id,
        string name,
        string miningStatus,
        string currentMiner,
        decimal currentHashrate,
        decimal currentTemperature,
        DateTimeOffset lastUpdateDate)
    {
        Id = id;
        Name = name;
        MiningStatus = miningStatus;
        CurrentMiner = currentMiner;
        CurrentHashrate = currentHashrate;
        CurrentTemperature = currentTemperature;
        CreatedDate = DateTimeOffset.Now;
        LastUpdateDate = lastUpdateDate;
    }
}