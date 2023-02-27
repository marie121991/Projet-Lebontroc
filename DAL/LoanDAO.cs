public class LoanDAO
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // public Guid IdOwner { get; set; }
    // public AppUserDAO Owner { get; set; }

    public Guid IdBorrower { get; set; }
    public AppUserDAO Borrower { get; set; }
    public Guid IdObject { get; set; }

    // public ObjectDAO Object { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime AnticipatedEndDate { get; set; }

    public DateTime? ActualEndDate { get; set; }

    public int StateLoan { get; set; }
    //StateLoan.Accepted ==> 2

    public Review OwnerReview { get; set; }
    public Review BorrowerReview { get; set; }

}