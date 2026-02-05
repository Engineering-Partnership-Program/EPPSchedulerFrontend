using System.Diagnostics.CodeAnalysis;

namespace EPPSchedulerFrontend.DataClasses;

public class Credentials
{
    public required string email { get; set; }
    public required string password { get; set; }
    public string? role { get; set; }

    [SetsRequiredMembers]
    public Credentials(string email, string password, string? role)
    {
        this.email = email;
        this.password = password;
        this.role = role;
    }
}