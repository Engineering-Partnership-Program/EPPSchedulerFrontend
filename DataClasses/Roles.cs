namespace EPPSchedulerFrontend.DataClasses;

public enum Roles
{
    User,
    Manager,
    Admin
}

public static class RoleTools
{
    public static string RoleConverter(Roles? role)
    {
        ArgumentNullException.ThrowIfNull(role);
        switch(role)
        {
            case Roles.User:
                return "User";
            case Roles.Manager:
                return "Manager";
            case Roles.Admin:
                return "Admin";
            default:
                throw new ArgumentException("Enum value not in known list of roles");
        }
    }
} 