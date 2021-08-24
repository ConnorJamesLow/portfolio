
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Portfolio2021.Data;

public interface IAppState
{
    List<Project> Projects { get; }
    List<Technology> Technologies { get; }
    Project? Current { get; }
    Task InitializeAsync();
    bool HasInitialized { get; }
    event Action? StateHasChanged;
    void SetCurrent(string key);
}

public class Store : IAppState
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigation;

	public Store(HttpClient http, NavigationManager navigation)
	{
		_http = http;
		_navigation = navigation;
	}

	public bool HasInitialized { get; private set; }
    List<Project> IAppState.Projects => Projects ?? throw new ArgumentNullException(nameof(Projects));
    List<Technology> IAppState.Technologies => Technologies ?? throw new ArgumentNullException(nameof(Technologies));
    private List<Project>? Projects { get; set; }
    private List<Technology>? Technologies { get; set; }
	public Project? Current { get; private set;  }

	public event Action? StateHasChanged;

    public async Task InitializeAsync()
    {
        Projects = await _http.GetFromJsonAsync<List<Project>>("data/projects.json");
        Technologies = await _http.GetFromJsonAsync<List<Technology>>("data/technologies.json");
        HasInitialized = true;
        Console.WriteLine("HasInitialized.");
        StateHasChanged?.Invoke();
    }

    public void SetCurrent(string key)
	{
        Current = Projects?.First(p => p.Key == key);
        StateHasChanged?.Invoke();
    }
}
