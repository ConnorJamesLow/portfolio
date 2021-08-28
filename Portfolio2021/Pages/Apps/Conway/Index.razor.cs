using Microsoft.AspNetCore.Components;
using Portfolio2021.Shared;
using System.ComponentModel.DataAnnotations;

namespace Portfolio2021.Pages.Apps.Conway
{
    public partial class Index
    {
        #region State
        private bool[,] Grid { get; set; } = new bool[10, 10];
        private SizeInputs SizeModel { get; set; } = new();
        private Tog Playing { get; set; } = new();
        private int GenerationDuration { get; set; } = 500;
        private CancellationTokenSource GameLoopSource { get; set; } = new();
        private int Generation { get; set; } = 1;
        private int Population { get; set; }
        #endregion

        #region Computed
        private MarkupString Styles => new($@"<style>
	.conway.grid {{
		grid-template-columns: repeat({Grid.GetLength(0)}, min({100f / Grid.GetLength(0)}vw, calc((100vh - 64px - 40px) / {Grid.GetLength(1)})));
        grid-template-rows: repeat({Grid.GetLength(1)}, min({100f / Grid.GetLength(0)}vw, calc((100vh - 64px - 40px) / {Grid.GetLength(1)})));
	}}

    .conway.cell {{
        border-radius: 8%;
    }}
</style>");
        #endregion

        private bool[,] GetNextGeneration(bool[,] current)
        {
            int columns = Grid.GetLength(0);
            int rows = Grid.GetLength(1);
            bool[,] next = new bool[columns, rows];
            Population = 0;
            foreach (int x in Enumerable.Range(0, columns))
            {
                foreach (int y in Enumerable.Range(0, rows))
                {
                    // Get neighbors:
                    int liveNeighbors = 0;
                    foreach (int offsetX in Enumerable.Range(-1, 3))
                    {
                        foreach (int offsetY in Enumerable.Range(-1, 3))
                        {
                            if ((offsetX is 0 && offsetY is 0)
                                || x + offsetX < 0 || x + offsetX >= columns
                                || y + offsetY < 0 || y + offsetY >= rows)
                            {
                                continue;
                            }
                            liveNeighbors += current[x + offsetX, y + offsetY] ? 1 : 0;
                        }
                    }

                    // Determine state:
                    if ((current[x, y] && liveNeighbors is 2 or 3) || liveNeighbors is 3)
                    {
                        next[x, y] = true;
                        Population++;
                    }
                    else
                    {
                        next[x, y] = false;
                    }
                }
            }
            return next;
        }

        #region Life Cycle
        protected override async Task OnInitializedAsync()
        {
            await StartGameLoop().ConfigureAwait(false);
            await base.OnInitializedAsync();
        }

        private async Task StartGameLoop()
        {
            while (!GameLoopSource.Token.IsCancellationRequested)
            {
                await Task.Delay(GenerationDuration);
                if (Playing)
                {
                    await InvokeAsync(() =>
                    {
                        Step();
                        StateHasChanged();
                    });
                }
            }
        }
        #endregion

        #region Controls
        private void UpdateGrid()
        {
            Grid = new bool[SizeModel.Columns, SizeModel.Rows];
            Playing.IsActive = false;
            Generation = 1;
            Population = 0;
            Console.WriteLine($"Updated grid: {Grid}");
        }

        private void Toggle(int x, int y)
        {
            Grid[x, y] = !Grid[x, y];
            Population += Grid[x, y] ? 1 : -1;
        }

        private void Step()
        {
            Grid = GetNextGeneration(Grid);
            Generation++;
            Console.WriteLine("Step!");
        }
        #endregion

        #region Definitions
        private class SizeInputs
        {
            [Required]
            public int Columns { get; set; } = 10;
            [Required]
            public int Rows { get; set; } = 10;
        }
        #endregion

    }
}