using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using RecipeAppCommon.Model;

namespace ShellShowsListWhichShowsDetails.ViewModels
{
    public class CustomerDetailViewModel : Screen
    {
        private Customer _customer;

        public void WithCustomer(Customer customer)
        {
            _customer = customer;
        }
    }
}
