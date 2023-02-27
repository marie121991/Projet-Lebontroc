using System.Text.Json.Serialization;
public class UserModel
{
    public Guid Id { get; set; }

    [JsonPropertyName("Un")]
    public string? UserName { get; set; }

    [JsonPropertyName("Fn")]
    public string? FirstName { get; set; }

    [JsonPropertyName("Ln")]
    public string? LastName { get; set; }

    [JsonPropertyName("A")]
    public Address? Address { get; set; }

    [JsonPropertyName("P")]
    public string? PhotoUrl { get; set; }

    [JsonPropertyName("DI")]
    public DateTime? DateInscription { get; set; } = DateTime.Now;

    [JsonPropertyName("Os")]
    public ICollection<SearchResultModel>? Objs { get; set; }

    [JsonPropertyName("T")]
    public string? Token { get; set; }

    [JsonPropertyName("G")]
    public string[]? Groups { get; set; }

}