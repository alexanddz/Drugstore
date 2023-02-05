using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Drugstore.Views
{
    public partial class EditePage : ContentPage
    {
        private ListItems list;
        private Item item;
        private double priceOldItem;
        private string name;
        private string description;
        public EditePage(Item item, ListItems list)
        {
            priceOldItem = item.Price;
            name = item.Name;
            description = item.Description;
            this.item = item;
            this.list = list;
            BindingContext = item;
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void SaveAndPopRoot(object sender, EventArgs e)
        {
            list.UpdateDateInFile();
            await Navigation.PopModalAsync();
        }

        private async void cancel(object sender, EventArgs e)
        {
            item.Name = name;
            item.Description = description;
            item.Price = priceOldItem;
            await Navigation.PopModalAsync();
        }
        private void ToChangePrice(object sender, TextChangedEventArgs e)
        {
            if (entryPrice?.Text == "")
            {
                item.Price = 0;
                return;
            }

            if (entryPrice?.Text[0] == '-')
            {
                entryPrice.TextColor = Color.Red;
                item.Price = priceOldItem;
                return;
            }
            item.Price = Convert.ToDouble(entryPrice?.Text);
            entryPrice.TextColor = Color.Black;
        }
    }
}