public class SquareCellMatch :  ICellMatch
{
    private static int _matchCount;
    public void MatchControl(Cell currentCell, Cell previousCell = null)
    {
        CheckNeighborCell(currentCell, currentCell.neighborUp, previousCell);
        CheckNeighborCell(currentCell, currentCell.neighborDown, previousCell);
        CheckNeighborCell(currentCell, currentCell.neighborRight, previousCell);
        CheckNeighborCell(currentCell, currentCell.neighborLeft, previousCell);
        if(_matchCount >=2)
            MatchCloseControl(currentCell);
    }

    private void CheckNeighborCell(Cell currentCell, Cell neighborCell, Cell previousCell)
    {
        if ( neighborCell != null && neighborCell != previousCell && neighborCell.isOpened)
        {
            _matchCount+=1;
            MatchControl((SquareCell)neighborCell,currentCell);
        }
    }

    public void MatchCloseControl(Cell currentCell, Cell previousCell = null)
    {
        CheckNeighborCellClose(currentCell, currentCell.neighborUp, previousCell);
        CheckNeighborCellClose(currentCell, currentCell.neighborDown, previousCell);
        CheckNeighborCellClose(currentCell, currentCell.neighborRight, previousCell);
        CheckNeighborCellClose(currentCell, currentCell.neighborLeft, previousCell);
        ResetMatchCount();
        currentCell.CloseCell();
    }

    public void ResetMatchCount()
    {
        _matchCount = 0;
    }

    private void CheckNeighborCellClose(Cell currentCell, Cell neighborCell, Cell previousCell)
    {
        if ( neighborCell != null && neighborCell != previousCell && neighborCell.isOpened)
        {
            MatchCloseControl((SquareCell)neighborCell,currentCell);
        }
    }
}
