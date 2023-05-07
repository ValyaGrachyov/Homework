namespace DataAccess.Entities;

public class Service : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}