using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Text.Json;
using System.ComponentModel;
using Microsoft.Windows.BadgeNotifications;
using System.ComponentModel.DataAnnotations;

namespace WinUI.Models
{
    public class AllToDos
    {
        public ObservableCollection<ToDoModel> ToDos { get; } = new();
        private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        public AllToDos()
        {
        }
        public async Task AddToDo(string title, string text, DateTime date)
        {
            ToDos.Add(new ToDoModel(title, text, date));
            await SaveAsync();
        }
        private async Task sortCollection()
        {
            var sortedToDos = new ObservableCollection<ToDoModel>(ToDos.OrderBy(todo => todo.Date));
            ToDos.Clear();
            foreach (var todo in sortedToDos)
            {
                ToDos.Add(todo);
            }
        }
        public async Task SaveAsync()

        {
            BadgeNotificationManager.Current.SetBadgeAsCount((uint)ToDos.Count);
            await sortCollection();
            string json = JsonSerializer.Serialize(ToDos,jsonOptions);
            StorageFile file = await storageFolder.CreateFileAsync("todos.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, json);
        }
        public async Task LoadAsync()
        {
            StorageFile file = await storageFolder.CreateFileAsync("todos.json", CreationCollisionOption.OpenIfExists);
            string json = await FileIO.ReadTextAsync(file);
            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }
            var loadedToDos = JsonSerializer.Deserialize<ObservableCollection<ToDoModel>>(json);
            if (loadedToDos != null)
            {
                ToDos.Clear();
                foreach (var todo in loadedToDos)
                {
                    ToDos.Add(todo);
                }
            }
        }
    }
}
