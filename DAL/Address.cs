using Microsoft.EntityFrameworkCore;
[Owned]
public class Address
{
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }

}