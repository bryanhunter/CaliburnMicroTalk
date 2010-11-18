using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using RecipeAppCommon.Framework;
using RecipeAppCommon.Model;

namespace ShellShowsListWhichShowsDetails.ViewModels
{
    public class CustomerListItemViewModel : Screen
    {
        public CustomerListItemViewModel(Guid id, string customerName)
        {
            Id = id;
            CustomerName = customerName;
        }

        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }

        public IEnumerable<IResult> ShowCustomerDetail()
        {
            var getCustomer = new GetCustomerQuery {Id = Id}.AsResult();

            yield return getCustomer;
            
            yield return Show.Child<CustomerDetailViewModel>().In<IShell>()
                .Configured(x => x.WithCustomer(getCustomer.Response));

            
        
        }
    }
}
