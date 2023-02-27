using Microsoft.AspNetCore.Identity;

public class UserDAO : IdentityUser<Guid>
{
    public UserDAO()
    {
        this.Id = Guid.NewGuid();
    }
}