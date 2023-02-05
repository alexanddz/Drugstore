using System;
using Xamarin.Forms;

namespace Drugstore.Views
{
    public partial class SchowPage : ContentPage
    {
        private ListItems List;
        public SchowPage(ListItems list)
        {
            List = list;
            BindingContext = List;
            InitializeComponent();
            isEmpty();
        }

        private void isEmpty()
        {
            int n = List.listItems.Count;

            if (n == 0)
            {
                labelHeader.Text = "Список товаров пуст";
                return;
            }

            labelHeader.Text = $"Количество: {n}";
                
        }

        private void ImageButtonRemove(object sender, EventArgs e )
        {
            TappedEventArgs eventArgs = new TappedEventArgs(e);
            object ob = ((TappedEventArgs)e).Parameter;
            Item item = ob as Item;
            if (item != null)
                List.RemoveToDo(item);
            isEmpty();
        }
    }
}