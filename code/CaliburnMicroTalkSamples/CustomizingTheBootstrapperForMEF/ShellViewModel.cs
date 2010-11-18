using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;

namespace CustomizingTheBootstrapperForMEF
{
    [Export(typeof (IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        [Import(typeof (WidgetViewModel))]
        public object ActiveView { get; set; }

        public void SayHello()
        {
            MessageBox.Show(string.Format("Hello there")); // Just for the sample. Not a great thing to do.
        }
    }
}