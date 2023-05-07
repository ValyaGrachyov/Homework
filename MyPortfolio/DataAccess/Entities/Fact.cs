namespace DataAccess.Entities;

public class Fact : IEntity
{
    public int Id { get; set; }
    public int HappyClients { get; set; }
    public int Projects { get; set; }
    public int HoursOfSupport { get; set; }
    public int HardWorkers { get; set; }
}