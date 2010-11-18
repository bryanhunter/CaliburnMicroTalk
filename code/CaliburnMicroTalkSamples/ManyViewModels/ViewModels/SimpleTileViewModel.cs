using Caliburn.Micro;

namespace ManyChildren.ViewModels
{
    public class SimpleTileViewModel : Screen
    {
        public SimpleTileViewModel()
        {
            CellSize = 20;
        }

        public int TileValue { get; set; }
        public int CellSize { get; set; }
        public void CountDown()
        {
            TileValue--;
            CellSize += 2;
            NotifyOfPropertyChange(() => TileValue);
            NotifyOfPropertyChange(() => CellSize);

        }


    }
}