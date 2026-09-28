using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using WinUI.Models;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ToDoPage : Page
{
    private AllToDos allToDos = new();

    public ToDoPage()
    {
        InitializeComponent();
        this.Loaded += async (sender, e) => await allToDos.LoadAsync();
    }

    private async void AddToDo_Click(object sender, RoutedEventArgs e)
    {
        await allToDos.AddToDo("New Task", "This is a new task.");
    }

    private async void DeleteToDo_Click(object sender, RoutedEventArgs e)
    {
        if (ToDoListView.SelectedItem is ToDoModel selectedToDo)
        {
            allToDos.ToDos.Remove(selectedToDo);
            await allToDos.SaveAsync();
        }
    }
}