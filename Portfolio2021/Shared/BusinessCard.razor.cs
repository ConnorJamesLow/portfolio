using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Portfolio2021.Shared;
public partial class BusinessCard
{

    #region Injected Services
    [Inject]
    private IJSRuntime JS { get; set; } = default!;
    #endregion

    private ElementReference CardElement { get; set; }

    #region Life Cycle
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            //await JS.InvokeVoidAsync("lib.fx.rotate3d", CardElement, 4, 8);
        }
        await base.OnAfterRenderAsync(firstRender);
    }
    #endregion
}
