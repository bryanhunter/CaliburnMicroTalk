using System;
using Caliburn.Micro;

namespace GameLibrary.Framework.Results
{
    public class BusyResult : IResult
    {
        private readonly object _busyViewModel;
        private readonly bool _isBusy;

        public BusyResult(bool isBusy, object busyViewModel)
        {
            _isBusy = isBusy;
            _busyViewModel = busyViewModel;
        }

        #region IResult Members

        public void Execute(ActionExecutionContext context)
        {
            object sourceViewModel = context.Target;

            if (_isBusy)
                IoC.Get<IBusyService>().MarkAsBusy(sourceViewModel, _busyViewModel);
            else
                IoC.Get<IBusyService>().MarkAsNotBusy(sourceViewModel);

            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        #endregion
    }
}