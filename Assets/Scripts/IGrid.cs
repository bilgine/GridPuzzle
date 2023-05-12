using UnityEngine;

public interface IGrid
{
    public void GridGenerate(Transform gridParent);
    public void GridReGenerate(int size);
    public void GridPoolGenerate();
}    
