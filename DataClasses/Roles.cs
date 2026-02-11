namespace EPPSchedulerFrontend.DataClasses;

public enum Roles
{
    User,
    Manager,
    Admin
}

public static class RoleTools
{
    public static string RoleToString(Roles? role)
    {
        ArgumentNullException.ThrowIfNull(role);

        switch (role)
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

    public static Roles StringToRole(string? role)
    {
        ArgumentNullException.ThrowIfNull(role);

        switch (role)
        {
            case "User":
                return Roles.User;
            case "Manager":
                return Roles.Manager;
            case "Admin":
                return Roles.Admin;
            default:
                throw new ArgumentException($"{role} does not have a corresponding enum value");
        }
    }
}