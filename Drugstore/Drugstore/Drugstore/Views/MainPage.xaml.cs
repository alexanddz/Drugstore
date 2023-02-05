using Drugstore.Views;
using System;
using Xamarin.Forms;

namespace Drugstore
{
    public partial class MainPage : ContentPage
    {
        private ListItems listitems;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            listitems = new ListItems();
        }

        private async void JumpToSchow(object sender, EventArgs e) => await Navigation.PushAsync(new SchowPage(listitems));
        private async void JumpToAdd(object sender, EventArgs e) => await Navigation.PushAsync(new AddItems(listitems));
        private async void JumpToSearch(object sender, EventArgs e) => await Navigation.PushAsync(new SearchPage(listitems));
        private void Exit(object sender, EventArgs e)
        {
            listitems.UpdateDateInFile();
            System.Environment.Exit(0);
        }
    }
}
