using ServiceLocatorSystem;
using UnityEngine;

public class CameraController : MonoBehaviour, IService
{
        private SquareGrid _squareGrid;
        
        public void OnRegisterComplete()
        {
        }

        public void OnContainerStart()
        {
                _squareGrid = ContainerManager.GetContainer(Container.Game).ServiceLocator.Resolve<SquareGrid>();
                _squareGrid.GridGenerated += SetCameraPosition;
        }
        
        private void SetCameraPosition(int size, float gridSpaceSize)
        {
                var cameraX = (size-1) * gridSpaceSize / 2f;
                transform.position = new Vector3(cameraX, 0, - size - size * gridSpaceSize);
        }

        private void OnDestroy()
        {
                _squareGrid.GridGenerated -= SetCameraPosition;
        }
}