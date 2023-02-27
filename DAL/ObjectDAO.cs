using System.ComponentModel.DataAnnotations;

public class ObjectDAO
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Label { get; set; }
    public int State { get; set; }
    public string Description { get; set; }
    public Guid IdOwner { get; set; }
    public AppUserDAO Owner { get; set; }

    public double Value { get; set; }

    public ICollection<PhotoDAO>? Photos { get; set; }

    public int ObjectState { get; set; }

    public DateTime UploadDate { get; set; } = DateTime.Now;

}