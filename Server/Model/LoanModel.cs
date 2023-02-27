using System.Text.Json.Serialization;

public class LoanModel
{
    public Guid Id { get; set; }

    [JsonPropertyName("IdO")]
    public Guid IdObject { get; set; }

    [JsonPropertyName("SD")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("AtED")]
    public DateTime AnticipatedEndDate { get; set; }

    [JsonPropertyName("AlED")]

    public DateTime? ActualEndDate { get; set; }

    [JsonPropertyName("SL")]
    public int StateLoan { get; set; }

    [JsonPropertyName("OR")]
    public Review OwnerReview { get; set; }

    [JsonPropertyName("BR")]
    public Review BorrowerReview { get; set; }
}