using Android.App;
using Drugstore.Droid;
using Drugstore.Interface;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

[assembly:Xamarin.Forms.Dependency(typeof(FileService))]
namespace Drugstore.Droid
{
    public class FileService : IFileService
    {
        private string path;

        public FileService()
        {
            string filename = "file.json";
            path = Path.Combine(GetRootPath(), filename);
            if(!File.Exists(path))
            File.Create(path).Close();
        }
        private string GetRootPath()
        {
            return Application.Context.GetExternalFilesDir(null).ToString();
        }
        public void WriteDate(ObservableCollection<Item> listFile)
        {
            using (StreamWriter r = new StreamWriter(path))
            {
                var items = JsonConvert.SerializeObject(listFile);
                r.WriteLine(items);
            }
        }
        public void ReadDate(ObservableCollection<Item> listFile)
        {

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(json);

                if(items != null)
                foreach (var item in items)
                    listFile.Add(item);

            }
        }
    }
}