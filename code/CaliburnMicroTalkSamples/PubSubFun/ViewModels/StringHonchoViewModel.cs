using Caliburn.Micro;
using PubSubFun.Messages;

namespace PubSubFun.ViewModels
{
    public class StringHonchoViewModel : PropertyChangedBase
    {
        public string TheString { get; set; }

        public void PublishIt()
        {
            var news = new CoolStringNews(TheString);

            IoC.Get<IEventAggregator>().Publish(news);
        }
    }
}