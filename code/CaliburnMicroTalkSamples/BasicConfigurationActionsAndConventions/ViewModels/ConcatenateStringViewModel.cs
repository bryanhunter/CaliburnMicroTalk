using Caliburn.Micro;

namespace BasicConfigurationActionsAndConventions.ViewModels
{
    public class ConcatenateStringViewModel : PropertyChangedBase
    {
        private string _twoStringOutput;

        // Convention binds a Button on the View named ConcatenateStrings to this method and the 
        // two arguments are bound to two textboxes on the view that match the parameter names.
        public void ConcatenateStrings(string firstString, string secondString)
        {
            string answer = string.Format("{0} {1}", firstString, secondString);

            TwoStringOutput = answer;
        }

        // Convention binds our answer to a TextBlock in the view
        public string TwoStringOutput
        {
            get { return _twoStringOutput; }
            private set
            {
                _twoStringOutput = value;
                NotifyOfPropertyChange(() => TwoStringOutput);
            }
        }

    }
}