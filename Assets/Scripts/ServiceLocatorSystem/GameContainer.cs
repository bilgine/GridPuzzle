namespace ServiceLocatorSystem
{
    public class GameContainer : BaseContainer
    {
        public override Container Type => Container.Game;

        protected override void Install()
        {
            ServiceLocator.RegisterMono<GridGenerator>();
            ServiceLocator.Register<SquareGrid>();
            ServiceLocator.RegisterMono<Pool>();
        }
    }
}