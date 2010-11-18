using System.Collections.Generic;

namespace GameLibrary.Model
{
    public class SearchGames : IQuery<IEnumerable<SearchResult>>
    {
        public string SearchText { get; set; }
    }
}