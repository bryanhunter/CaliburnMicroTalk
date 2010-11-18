using System.ComponentModel.Composition;
using Caliburn.Micro;
using GameLibrary.Framework;
using GameLibrary.Framework.Results;

namespace GameLibrary.ViewModels
{
    [Export(typeof (NoResultsViewModel))]
    public class NoResultsViewModel
    {
        private string _searchText;

        public IResult AddGame()
        {
            return Show.Child<AddGameViewModel>()
                .In<IShell>()
                .Configured(x => x.Title = _searchText);
        }

        public NoResultsViewModel WithTitle(string searchText)
        {
            _searchText = searchText;
            return this;
        }
    }
}