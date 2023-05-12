using System;
using ServiceLocatorSystem;
using UnityEngine;

public class MatchManager: MonoBehaviour, IService
{
    private CellSelectionResponse _selectionManager;
    private ICellMatch _cellMatch;

    public void OnRegisterComplete()
    {
    }

    public void OnContainerStart()
    {
        _cellMatch = ContainerManager.GetContainer(Container.Game).ServiceLocator.Resolve<SquareCellMatch>();
        _selectionManager = ContainerManager.GetContainer(Container.Game).ServiceLocator.Resolve<CellSelectionResponse>();
        _selectionManager.Clicked += CheckMatch;
    }

    private void CheckMatch(Cell cell)
    {
        _cellMatch.ResetMatchCount();
        _cellMatch.MatchControl(cell);
    }

    private void OnDestroy()
    {
        _selectionManager.Clicked -= CheckMatch;
    }
}    
