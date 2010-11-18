using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace PubSubFun.ViewModels
{
    [Export(typeof (IShell))]
    public class ShellViewModel : Conductor<IScreen>, IShell
    {
        public ShellViewModel()
        {
            NumberHoncho = new NumberHonchoViewModel();
            PrimitiveFan = new PrimitiveFanViewModel();
            StringHoncho = new StringHonchoViewModel();
        }

        public NumberHonchoViewModel NumberHoncho { get; private set; }
        public StringHonchoViewModel StringHoncho { get; private set; }
        public PrimitiveFanViewModel PrimitiveFan { get; private set; }
    }
}