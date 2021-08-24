using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio2021.Data;

namespace Portfolio2021.Shared
{
    public partial class MainLayout
    {

		#region Injected Services
		[Inject] NavigationManager Navigator { get; set; } = default!;
        [Inject] IAppState State { get; set; } = default!;

        #endregion

        #region Life Cycle
        protected override void OnInitialized()
        {
            State.StateHasChanged += StateHasChanged;
        }

        protected override async Task OnInitializedAsync()
        {
            await State.InitializeAsync();
            await base.OnInitializedAsync();
        }
        #endregion

    }
}