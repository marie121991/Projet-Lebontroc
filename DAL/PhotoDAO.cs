public class PhotoDAO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public byte[]? File { get; set; }
    public string? Comment { get; set; }
    public Guid IdObject { get; set; }
    public ObjectDAO Object { get; set; }

}