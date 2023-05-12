public interface ICellMatch
{
    public void MatchControl(Cell currentCell, Cell previousCell = null);

    public void MatchCloseControl(Cell currentCell, Cell previousCell = null);
    
    public void ResetMatchCount();
}
