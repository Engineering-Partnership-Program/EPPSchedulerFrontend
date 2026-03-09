using System.IO.Pipes;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using EPPSchedulerFrontend.DataClasses;
using Microsoft.AspNetCore.Components.Authorization;

public class AuthenticationService : AuthenticationStateProvider
{
    private readonly IHttpClientFactory _clientFactory;

    public AuthenticationService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        HttpClient client = _clientFactory.CreateClient("EPPSchedulerBackend");

        try
        {
            Roles? user = await client.GetFromJsonAsync<Roles>("/api/Credentials/verify");

            if (user is null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            ClaimsIdentity identity = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, "User"),
                    new Claim(ClaimTypes.Role, RoleTools.RoleToString(user)),
                ],
                "ServerCookieAuth",
                ClaimTypes.Name,
                ClaimTypes.Role
            );

            // ClaimsIdentity identity = new ClaimsIdentity(claims, "ServerCookieAuth");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            foreach (Claim claim in principal.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }

            return new AuthenticationState(principal);
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }

    public void NotifyUserAuthenticated(Roles userRole)
    {
        ClaimsIdentity identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, "User"),
                new Claim(ClaimTypes.Role, RoleTools.RoleToString(userRole)),
            ],
            "ServerCookieAuth",
            ClaimTypes.Name,
            ClaimTypes.Role
        );

        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }
}
