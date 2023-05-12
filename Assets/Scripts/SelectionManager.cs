using System;
using ServiceLocatorSystem;
using UnityEngine;

public class SelectionManager :MonoBehaviour, IService
{
    private ISelectionResponse _selectionResponse;

    public void OnRegisterComplete()
    {
    }

    public void OnContainerStart()
    {
        _selectionResponse = ContainerManager.GetContainer(Container.Game).ServiceLocator.Resolve<CellSelectionResponse>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            _selectionResponse.OnHitObject(hit);
        }
    }
}    


