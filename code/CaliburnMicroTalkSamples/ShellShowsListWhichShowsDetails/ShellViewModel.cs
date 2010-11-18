using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using RecipeAppCommon.Framework;
using ShellShowsListWhichShowsDetails.ViewModels;

namespace ShellShowsListWhichShowsDetails
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>, IShell
    {
        public ShellViewModel()
        {
            DisplayName = "Recipe Shell";
        }

        public void ShowCustomerList()
        {
            
            IoC.Get<IWindowManager>().ShowDialog(new CustomerListViewModel());

        }
        
    }
}
