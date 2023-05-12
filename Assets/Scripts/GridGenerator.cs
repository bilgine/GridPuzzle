using ServiceLocatorSystem;
using UnityEngine;

public class GridGenerator : MonoBehaviour,IService
{
     private IGrid _grid;
     
     public void OnRegisterComplete()
     {
     }

     public void OnContainerStart()
     {
          _grid = ContainerManager.GetContainer(Container.Game).ServiceLocator.Resolve<SquareGrid>();
          _grid.GridGenerate(transform);
     }
}


