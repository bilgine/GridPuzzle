using Zenject;

public class GridGenerator : IInitializable
{
    private IGrid _grid;

    public void Initialize()
    {
        _grid.GridGenerate();
    }

    [Inject]
    public void Construct(SquareGrid grid)
    {
        _grid = grid;
    }
}