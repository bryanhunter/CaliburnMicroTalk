using Caliburn.Micro;
using PubSubFun.Messages;

namespace PubSubFun.ViewModels
{
    public class NumberHonchoViewModel : PropertyChangedBase
    {
        public int TheNumber { get; set; }

        public void PublishIt()
        {
            var news = new CoolNumberNews(TheNumber);

            IoC.Get<IEventAggregator>().Publish(news);
        }
    }
}