using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pool: IPool , IInitializable
{
    private Cell.Factory _cellFactory;
    private Queue<Cell> _inactiveItems;
    
    [Inject]
    public void Construct(Cell.Factory cell)
    {
        _cellFactory = cell;
    }
    
    public void Initialize()
    {
        _inactiveItems = new Queue<Cell>();
    }

    public Cell Spawn(Vector3 position, Quaternion rotation, Transform parent)
    {
        if (_inactiveItems.Count > 0)
        {
            Cell obj = _inactiveItems.Dequeue();
            obj.InitializeCell();
            Transform tform = obj.transform;
            tform.position = position;
            tform.rotation = rotation;
            tform.SetParent(parent);
            return obj;
        }
        else
        {
            Cell obj = _cellFactory.Create();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.transform.SetParent(parent);
            obj.InitializeCell();
            return obj;
        }
    }
     
    public void DeSpawn(Cell obj)
    {
        if (obj == null)
            return;

        obj.SetCellDefault();
        _inactiveItems.Enqueue(obj);
    }

    
}
