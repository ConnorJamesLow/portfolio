using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio2021.Data;
using System.Net.Http.Json;

namespace Portfolio2021.Shared;
public partial class Featured
{
	static readonly int T = 0;
	#region Injected Services
	[Inject]
	private IJSRuntime JS { get; set; } = default!;
	[Inject]
	IAppState State { get; set; } = default!;
	#endregion

	#region State
	private List<Project> Projects => State.Projects;
	private List<Technology> Technologies => State.Technologies;
	private bool IsEmpty { get; set; }
	#endregion

	#region Life Cycle
	protected override async Task OnInitializedAsync()
	{
		IsEmpty = Projects?.Any() is not true && Technologies?.Any() is not true;
		await base.OnInitializedAsync();
	}
	#endregion
}
