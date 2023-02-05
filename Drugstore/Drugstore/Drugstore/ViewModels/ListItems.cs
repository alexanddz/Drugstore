using System.Collections.ObjectModel;
using Xamarin.Forms;
using Drugstore.Interface;

namespace Drugstore
{
    public class ListItems
    {
        public ObservableCollection<Item> listItems { get;}
        public ListItems()
        {
            listItems = new ObservableCollection<Item>();
            DependencyService.Get<IFileService>().ReadDate(listItems);
        }

        public void Add(object ob)
        {
            Item item = ob as Item;
            listItems.Add(item);

            UpdateDateInFile();
        }
        public void RemoveToDo(Item item)
        {
            listItems.Remove(item);

            UpdateDateInFile();
        }

        public void UpdateDateInFile()
        {
            DependencyService.Get<IFileService>().WriteDate(listItems);
        }
    }
}
