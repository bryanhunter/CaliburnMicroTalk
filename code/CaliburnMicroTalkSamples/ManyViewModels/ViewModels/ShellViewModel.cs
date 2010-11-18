using Caliburn.Micro;

namespace ManyChildren.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            // By convention a collection property on a ViewModel with the same name as an ItemsControl 
            // on a View will result in Views (one for each collection item) being loaded into the ItemsControl.
            Tiles = new BindableCollection<SimpleTileViewModel>();
            
        }

        public void LoadManyTile()
        {
            // Adding a 100 view models is pretty quick.
            
            for (int i = 0; i < 100; i++)
            {
                // Add another ViewModel to the collection and a new View will be automatically created and bound.
                // See ViewModelBinder, ViewLocator, and ConventionManager::AddCustomBindingBehavior
                Tiles.Add(new SimpleTileViewModel
                               {
                                   TileValue = i
                               });
            }
        }
        
        public BindableCollection<SimpleTileViewModel> Tiles { get; private set;}

    }
}