using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

public class BaseComponent : ComponentBase
{
    [Inject]
    protected NavigationManager? navigationManager { get; set; }

    [Inject]
    protected ISnackbar? snackbar { get; set; }

    [Inject]
    protected IHttpClientFactory? clientFactory { get; set; }

    [Inject]
    protected AuthenticationStateProvider? authenticationService { get; set; }
}
