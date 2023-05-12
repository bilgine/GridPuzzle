using System.Collections.Generic;
using UnityEngine;

public class Pool: MonoBehaviour, IPool
{
    [SerializeField] Cell cellPrefab;
    private Queue<Cell> _inactiveItems;

    private void Awake()
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
            Cell obj = Instantiate(cellPrefab, position, rotation, parent);
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
