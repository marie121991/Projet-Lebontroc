public class AppUserDAO
{
    public Guid Id { get; set; }

    public string UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public Address? Address { get; set; }
    public UserDAO User { get; set; }

    public string? PhotoUrl { get; set; }
    public ICollection<ObjectDAO>? Objects { get; set; }
    public DateTime? DateInscription { get; set; } = DateTime.Now;
    public ICollection<LoanDAO>? Loans { get; set; }
}