using Caliburn.Micro;

namespace BasicConfigurationActionsAndConventions.ViewModels
{
    public class MessageViewModel : Screen
    {
        public MessageViewModel()
        {
            
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(()=>Message);
            }
        }
    }
}