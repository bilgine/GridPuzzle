namespace ServiceLocatorSystem
{
    public class GameContainer : BaseContainer
    {
        public override Container Type => Container.Game;

        protected override void Install()
        {
            /*ServiceLocator.RegisterMono<CameraController>();
            ServiceLocator.RegisterMono<GridGenerator>();
            ServiceLocator.Register<SquareGrid>();
            ServiceLocator.RegisterMono<Pool>();
            ServiceLocator.RegisterMono<SelectionManager>();
            ServiceLocator.RegisterMono<MatchManager>();
            ServiceLocator.Register<SquareCellMatch>();
            ServiceLocator.Register<CellSelectionResponse>();*/
        }
    }
}