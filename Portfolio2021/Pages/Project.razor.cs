using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio2021.Data;
using System.Threading.Tasks;

namespace Portfolio2021.Pages
{
    public partial class Project
    {

		#region Injected Services
		[Inject] IAppState State { get; set; } = default!;
		#endregion

		#region Parameters
		private string? Id_Field;

        [Parameter]
        public string Id
        {
            get => Id_Field ?? throw new ArgumentNullException(nameof(Id_Field)); 
            set => Id_Field = value;
        }
		#endregion

		#region Computed
		private Data.Project? Model => State.Current;
		#endregion

		#region Life Cycle
		protected override void OnParametersSet()
		{
			if (State.Current?.Key != Id)
			{
				State.SetCurrent(Id);
				Console.WriteLine(State);
			}
			base.OnParametersSet();
		}

		#endregion

	}
}