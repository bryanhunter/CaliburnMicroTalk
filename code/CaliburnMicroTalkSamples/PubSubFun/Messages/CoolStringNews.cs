namespace PubSubFun.Messages
{
    public class CoolStringNews
    {
        public CoolStringNews(string theString)
        {
            TheString = theString;
        }

        public string TheString { get; private set; }
    }
}