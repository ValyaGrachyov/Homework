namespace DataAccess.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    public string Birthday { get; set; }
    public string Website { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public int Age { get; set; }
    public string Degree { get; set; }
    public string PhEmailOne { get; set; }
    public string Freelance { get; set; }
}