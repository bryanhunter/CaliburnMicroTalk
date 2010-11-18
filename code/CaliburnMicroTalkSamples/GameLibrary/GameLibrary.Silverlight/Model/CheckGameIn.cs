using System;

namespace GameLibrary.Model
{
    public class CheckGameIn : ICommand
    {
        public Guid Id { get; set; }
    }
}