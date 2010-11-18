using System;

namespace GameLibrary.Model
{
    public class GetGame : IQuery<GameDTO>
    {
        public Guid Id { get; set; }
    }
}