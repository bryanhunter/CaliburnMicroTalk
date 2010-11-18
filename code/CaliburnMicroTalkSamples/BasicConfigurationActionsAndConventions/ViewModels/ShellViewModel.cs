using System.Windows;
using Caliburn.Micro;
using System;

namespace BasicConfigurationActionsAndConventions.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string _name;

        public ShellViewModel()
        {
            ConcatenateStringPanel = new ConcatenateStringViewModel();

            DisplayName = "Basic Configuration, Actions and Conventions";
        }
        
        // ViewModel property wired to View's TextBox via convention
        // Convention wires the View's "Name" TextBox to the this string property 
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        // ViewModel method wired to the View's ButtonClick via convention
        // Convention wires the View's "SayHello" button to this method
        public void SayHello()
        {
            string text = string.Format("Hello {0}!", Name);

             MessageBox.Show(text); // Don't do this in real life :) 

            // something like this would be better
            //var messageViewModel = new MessageViewModel {Message = text};
            //new WindowManager().Show(messageViewModel);  

            // Even better: use dependency injection to make a MessageBox service available
        }

        // Convention sets this CanSayHello as a guard for the SayHello method above
        public bool CanSayHello
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        // In the ShellView.xaml a ContentControl with the name "ConcatenateStringPanel" exists
        // The following public property has the same name. By convention the View that matches this 
        // type will be loaded into the ContentControl
        public ConcatenateStringViewModel ConcatenateStringPanel { get; set; }

        
    }
}