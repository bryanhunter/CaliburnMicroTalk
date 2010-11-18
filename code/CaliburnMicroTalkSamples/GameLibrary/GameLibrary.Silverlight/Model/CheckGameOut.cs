using System;

namespace GameLibrary.Model
{
    public class CheckGameOut : ICommand
    {
        public Guid Id { get; set; }
        public string Borrower { get; set; }
    }
}