using UnityEngine;
using Zenject;

public class GridGameInstaller : MonoInstaller
{
    [SerializeField] private GameObject cell;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SelectionManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<MatchManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<Pool>().AsSingle();
        Container.BindInterfacesAndSelfTo<GridGenerator>().AsSingle();
        Container.Bind<SquareGrid>().AsSingle();
        Container.Bind<CellSelectionResponse>().AsSingle();
        Container.Bind<SquareCellMatch>().AsSingle();
        Container.BindFactory<Cell, Cell.Factory>()
            .FromComponentInNewPrefab(cell);
    }
}