namespace DataAccess.Entities;

public class Testimonial : IEntity
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string AuthorName { get; set; }
    public string AuthorOccupation { get; set; }
}