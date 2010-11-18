using System;

namespace GameLibrary.Model
{
    public interface IBackend
    {
        void Send(ICommand command);
        void Send<TResponse>(IQuery<TResponse> query, Action<TResponse> reply);
    }
}