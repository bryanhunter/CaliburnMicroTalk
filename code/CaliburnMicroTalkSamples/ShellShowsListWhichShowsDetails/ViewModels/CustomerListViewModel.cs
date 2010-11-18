using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using RecipeAppCommon.Model;

namespace ShellShowsListWhichShowsDetails.ViewModels
{
    public class CustomerListViewModel : Screen
    {
        public CustomerListViewModel()
        {
            CustomerResults = new ObservableCollection<CustomerListItemViewModel>();

            this.DisplayName = "Customer List";
        }

        public void Search()
        {
            CustomerResults.Clear();


            var all = CustomerDataFeed.Search();

            foreach (var customer in all)
            {
                CustomerResults.Add(new CustomerListItemViewModel(customer.Id, customer.CustomerName));
            }

            NotifyOfPropertyChange(() => CustomerCountMessage);
        }

        public string CustomerCountMessage 
        { 
            get
            {
                return "Customer Count : " + CustomerResults.Count;
            }
        }

        public ObservableCollection<CustomerListItemViewModel> CustomerResults { get; private set; }

        protected override void OnInitialize()
        {
            
        }
    }
}
