namespace DataAccess.Entities;

public class Skill : IEntity
{
    public int Id { get; set; }
    public int Html { get; set; }
    public int Css { get; set; }
    public int JavaScript { get; set; }
    public int Php { get; set; }
    public int Wordpress { get; set; }
    public int Photoshop { get; set; }
}