using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Drugstore.Interface
{
    public interface IFileService
    {
        void ReadDate(ObservableCollection<Item> listItems);
        void WriteDate(ObservableCollection<Item> listItems);
    }
}
