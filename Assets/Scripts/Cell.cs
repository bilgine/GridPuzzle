using UnityEngine;
using Zenject;

public abstract class Cell : MonoBehaviour
{
    public bool isOpened;
    public Cell neighborUp;
    public Cell neighborRight;
    public Cell neighborLeft;
    public Cell neighborDown;

    public abstract void InitializeCell();

    public abstract void OpenCell();

    public abstract void CloseCell();

    public abstract void SetCellDefault();
    
    public class Factory : PlaceholderFactory<Cell>
    {
    }
    
}
