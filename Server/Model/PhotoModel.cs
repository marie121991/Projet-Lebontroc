using System.Text.Json.Serialization;
public class PhotoModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("f")]
    public byte[]? File { get; set; }

    [JsonPropertyName("c")]
    public string? Comment { get; set; }

    [JsonPropertyName("ido")]
    public Guid IdObject { get; set; }

}