using ServiceLocatorSystem;
using UnityEngine;

public class SquareGrid: IGrid
{
    private int _size = 10;
    private const float GridSpaceSize = .75f;
    private IPool _cellPool;
    private Cell[,] _squares;
    
    public delegate void OnGridGenerate(int size, float gridSpaceSize);
    public OnGridGenerate GridGenerated;
    
    
    public void GridGenerate(Transform parent = null)
    {
        _cellPool = ContainerManager.GetContainer(Container.Game).ServiceLocator.Resolve<Pool>();
        _squares = new Cell[_size, _size];
        InstantiateGrid();
        AssignSquareGridNeighbors(_squares);
        GridGenerated?.Invoke(_size,GridSpaceSize);
    }
    
    public void GridReGenerate(int newSize)
    {
        _size = newSize;
        GridPoolGenerate();
    }

    public void GridPoolGenerate()
    {
        foreach (var sqr in _squares)
        {
            _cellPool.DeSpawn(sqr);
        }
        GridGenerate();
    }
    
    private void InstantiateGrid(Transform parent = null)
    {
        for (var i = 0; i < _size; i++)
        {
            for (var j = 0; j < _size; j++)
            {
                _squares [i,j] = _cellPool.Spawn(new Vector3(i * GridSpaceSize, j * GridSpaceSize, 0),
                    Quaternion.identity, parent);
            }
        } 
    }
     
    private void AssignSquareGridNeighbors(Cell[,] squares) 
    {
        for (var x = 0; x < _size; x++)
        {
            for (var y = 0; y < _size; y++)
            {
                var cell =  squares[x,y];
                cell.neighborUp = y < _size - 1 ? squares[x, y + 1]:null;
                cell.neighborDown = y > 0 ? squares[x, y - 1]:null;
                cell.neighborLeft = x > 0 ? squares[x - 1, y]:null;
                cell.neighborRight = x < _size - 1 ? squares[x + 1, y]:null;
            }
        }
    }


    
}    
