using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Portfolio2021;
using Portfolio2021.Shared;
using Portfolio2021.Data;

namespace Portfolio2021.Shared;
public partial class ProjectItem
{

    #region Parameters
    [Parameter]
    public Project? Item { get; set; }
	#endregion

	#region Injected Services
	[Inject]
	private NavigationManager Navigator { get; set; } = default!;
	#endregion

	#region Computed
	public Project Model => Item ?? throw new ArgumentNullException(nameof(Item));
    #endregion

    private void Open() => Navigator.NavigateTo($"/Project/{Model.Key}");
}
