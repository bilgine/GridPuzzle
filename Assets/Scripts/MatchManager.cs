using Zenject;

public class MatchManager : IInitializable
{
    private CellSelectionResponse _selectionManager;
    private ICellMatch _cellMatch;

    [Inject]
    public void Construct(CellSelectionResponse cellSelection, SquareCellMatch cellMatch)
    {
        _selectionManager = cellSelection;
        _cellMatch = cellMatch;
    }

    private void CheckMatch(Cell cell)
    {
        _cellMatch.ResetMatchCount();
        _cellMatch.MatchControl(cell);
    }

    public void Initialize()
    {
        _selectionManager.Clicked += CheckMatch;
    }
}