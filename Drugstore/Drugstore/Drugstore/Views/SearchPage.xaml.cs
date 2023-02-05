using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Drugstore.Views
{
    public partial class SearchPage : ContentPage
    {
        private ListItems List;
        public SearchPage(ListItems listItems)
        {
            InitializeComponent();
            List = listItems;
            this.BindingContext = List;
        }

        private void SearchItem(object sender, TextChangedEventArgs e)
        {
            var listSearchWhere = List.listItems.Where(s => s.Name.StartsWith(e.NewTextValue));
            listSearch.ItemsSource = listSearchWhere;
        }

        private async void EditItemClicked(object sender, EventArgs e)
        {
            TappedEventArgs eventArgs = new TappedEventArgs(e);
            object ob = ((TappedEventArgs)e).Parameter;
            Item item = ob as Item;
            if (item != null)
            {
                EditePage editePage = new EditePage(item,List);
                await Navigation.PushModalAsync(editePage);
            }
        }
        protected override void OnAppearing()
        {
            listSearch.ItemsSource = null;
            listSearch.ItemsSource = List.listItems;
        }

    }
}