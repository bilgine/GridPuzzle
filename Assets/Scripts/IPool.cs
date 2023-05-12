using UnityEngine;

public interface IPool
{
    public Cell Spawn(Vector3 position, Quaternion rotation, Transform parent);
    public void DeSpawn(Cell obj);
}
