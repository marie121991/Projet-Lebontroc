using System.Text.Json.Serialization;
public class SearchResultModel

{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("l")]
    public string Label { get; set; }

    [JsonPropertyName("i")]
    public string? Indication { get; set; }

    [JsonPropertyName("sd")]
    public string? ShortDescription { get; set; }
}