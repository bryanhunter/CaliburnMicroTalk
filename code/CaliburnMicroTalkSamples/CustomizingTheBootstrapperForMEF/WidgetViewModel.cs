using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace CustomizingTheBootstrapperForMEF
{
    [Export(typeof (WidgetViewModel))]
    public class WidgetViewModel : Screen
    {
    }
}