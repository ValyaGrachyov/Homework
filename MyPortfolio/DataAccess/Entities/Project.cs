namespace DataAccess.Entities;

public class Project : IEntity
{
    public int Id { get; set; }
    public string Category { get; set; }
    public string Client { get; set; }
    public string Date { get; set; }
    public string Url { get; set; }
}