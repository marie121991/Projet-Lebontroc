using Microsoft.EntityFrameworkCore;
[Owned]
public class Review
{
    public int Rating { get; set; }
    public string Comment { get; set; }
}