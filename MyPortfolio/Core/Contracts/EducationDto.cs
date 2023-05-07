namespace Contracts;

public class EducationDto
{
    public int Id { get; set; }
    public string Specialization { get; set; }
    public string Degree { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string OrganizationName { get; set; }
    public string Description { get; set; }
}