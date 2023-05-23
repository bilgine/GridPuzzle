using UnityEngine;
using Zenject;

public class SelectionManager : ITickable
{
    private ISelectionResponse _selectionResponse;


    [Inject]
    public void Construct(CellSelectionResponse selection)
    {
        _selectionResponse = selection;
    }


    public void Tick()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit)) _selectionResponse.OnHitObject(hit);
    }
}