using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace Drugstore.Views
{
    public partial class AddItems : ContentPage
    {
        private ListItems listAddPage;
        public ICommand command { get; }
        public AddItems(ListItems listitems)
        {
            BindingContext = this;
            command = new Command(CheckToFill);
            InitializeComponent();
            listAddPage = listitems;
        }   
        private async void CheckToFill()
        {
            string name = entry1.Text;
            string price = entry2.Text;
            string description = entry3.Text;

            if (entry1Line.BackgroundColor == Color.Green && 
                entry2Line.BackgroundColor == Color.Green &&
                entry3Line.BackgroundColor == Color.Green)
            {
                Item item = new Item(name, description, Convert.ToDouble(price));
                listAddPage.Add(item);
                clearMethod(entry1, entry1Line);
                clearMethod(entry2, entry2Line);
                entry3.Text = "";
                entry3Line.BackgroundColor = Color.Transparent;
            }
            else
                await DisplayAlert(null, "Не все индикаторы нужного цвета!", "Ок");
        }
        private bool isValid(string text, string charStr = " ")
        {
            text = text?.Replace(charStr, string.Empty);
            return (text != null) && (text.Length != 0);
        }
        private void clearMethod(Entry entry,Ellipse ellipse)
        {
            entry.Text = "";
            ellipse.BackgroundColor = Color.Transparent;
        }
        private void entry1_UnFocused(object sender, FocusEventArgs e)
        {
            if (isValid(entry1.Text))
                entry1Line.BackgroundColor = Color.Green;
            else
                entry1Line.BackgroundColor = Color.Red;
        }
        private void entry2_UnFocused(object sender, FocusEventArgs e)
        {
            string price = entry2.Text;
            if (isValid(price) && isValid(price, "-") && Convert.ToDouble(price) >= 0)
                entry2Line.BackgroundColor = Color.Green;
            else
                entry2Line.BackgroundColor = Color.Red;
        }
        private void editor3_UnFocused(object sender, FocusEventArgs e)
        {
            if (isValid(entry3.Text))
                entry3Line.BackgroundColor = Color.Green;
            else
                entry3Line.BackgroundColor = Color.Red;
        }
    }
}