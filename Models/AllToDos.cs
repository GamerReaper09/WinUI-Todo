using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI.Models
{
    public class AllToDos
    {
        public ObservableCollection<ToDoModel> ToDos { get; } = new();
        public AllToDos()
        {
            ToDos.Add(new ToDoModel("Task 1", "This is the first task."));
            ToDos.Add(new ToDoModel("Task 2", "This is the second task."));
            ToDos.Add(new ToDoModel("Task 3", "This is the third task."));
        }
        public void AddToDo(string title, string text)
        {
            ToDos.Add(new ToDoModel(title, text));
        }
    }
}
