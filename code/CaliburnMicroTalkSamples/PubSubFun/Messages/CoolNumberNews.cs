namespace PubSubFun.Messages
{
    public class CoolNumberNews
    {
        public CoolNumberNews(int theNumber)
        {
            TheNumber = theNumber;
        }

        public int TheNumber { get; private set; }
    }
}