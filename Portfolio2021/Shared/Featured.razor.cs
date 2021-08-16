using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio2021.Data;
using System.Net.Http.Json;

namespace Portfolio2021.Shared;
public partial class Featured
{
    #region Injected Services
    [Inject]
    private IJSRuntime JS { get; set; } = default!;
    [Inject]
    HttpClient Http { get; set; } = default!;
    #endregion

    #region State
    private Project[]? Projects { get; set; }
    private bool IsEmpty { get; set; }
    #endregion

    #region Life Cycle
    protected override async Task OnInitializedAsync()
    {
        Project[]? projects = await Http.GetFromJsonAsync<Project[]>("data/projects.json");
        if (projects is null)
        {
            IsEmpty = true;
        }
        else
        {
            Projects = projects.Where(p => p.Featured).ToArray();
        }
        await base.OnInitializedAsync();
    }
    #endregion
}
