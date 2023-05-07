namespace Domain.Entities;

public class RequestMessage
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public bool Checked { get; set; }
}