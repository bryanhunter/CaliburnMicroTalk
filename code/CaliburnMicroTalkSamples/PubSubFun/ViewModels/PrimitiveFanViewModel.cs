using System;
using Caliburn.Micro;
using PubSubFun.Messages;

namespace PubSubFun.ViewModels
{
    public class PrimitiveFanViewModel : PropertyChangedBase, 
        IHandle<CoolNumberNews>, 
        IHandle<CoolStringNews>
    {
        public PrimitiveFanViewModel()
        {
            var eventAggregator = IoC.Get<IEventAggregator>();
            eventAggregator.Subscribe(this);
        }

        public string TheNews { get; set; }

        #region IHandle<CoolNumberNews> Members

        public void Handle(CoolNumberNews message)
        {
            TheNews = String.Format("{0}This number just  in...{1}\r\n", TheNews, message.TheNumber);
            NotifyOfPropertyChange(() => TheNews);
        }

        #endregion

        #region IHandle<CoolStringNews> Members

        public void Handle(CoolStringNews message)
        {
            TheNews = String.Format("{0}This string just in...\"{1}\"\r\n", TheNews, message.TheString);
            NotifyOfPropertyChange(() => TheNews);
        }

        #endregion
    }
}