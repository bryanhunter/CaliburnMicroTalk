using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace GameLibrary.Model
{
    public class QueryResult<TResponse> : IResult
    {
        private readonly IQuery<TResponse> _query;

        public QueryResult(IQuery<TResponse> query)
        {
            _query = query;
        }

        [Import]
        public IBackend Bus { get; set; }

        public TResponse Response { get; set; }

        #region IResult Members

        public void Execute(ActionExecutionContext context)
        {
            //TALK: Implemetatation of Bus.Send 
            // 1) finds a handler matching our query type
            // 2) Produces a result
            // 3) Pushes the results back to our Respose (as the execution of the Action)
            Action<TResponse> replyAction =
                resultOfWork =>
                    {
                        Response = resultOfWork;
                        Caliburn.Micro.Execute.OnUIThread(
                            () => Completed(this, new ResultCompletionEventArgs()));
                    };

            Bus.Send(_query, replyAction );
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        #endregion
    }
}