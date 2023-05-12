using UnityEngine;

public class CellSelectionResponse : ISelectionResponse
{
    public delegate void OnHit(Cell cell);
    public OnHit Clicked;
    public void OnHitObject(RaycastHit hit)
    {
        var cell = hit.transform.GetComponent<Cell>();
        cell.OpenCell();
        Clicked?.Invoke(cell);
    }
}
    
