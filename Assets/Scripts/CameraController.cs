using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    private SquareGrid _squareGrid;

    [Inject]
    public void Construct(SquareGrid squareGrid)
    {
        _squareGrid = squareGrid;
        SetGridGenerateEvent();
    }

    private void SetGridGenerateEvent()
    {
        _squareGrid.GridGenerated += SetCameraPosition;
    }


    private void SetCameraPosition(int size, float gridSpaceSize)
    {
        var cameraX = (size - 1) * gridSpaceSize / 2f;
        transform.position = new Vector3(cameraX, 0, -size - size * gridSpaceSize);
    }

    private void OnDestroy()
    {
        _squareGrid.GridGenerated -= SetCameraPosition;
    }
}