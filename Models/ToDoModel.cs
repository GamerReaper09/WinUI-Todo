using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI.Models
{
    public class ToDoModel
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public ToDoModel(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
