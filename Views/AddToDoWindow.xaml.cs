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
using Microsoft.UI.Windowing;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI.Views;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AddToDoWindow : Window
{
    private readonly AllToDos allToDos;
    public AddToDoWindow(AllToDos allToDos)
    {
        InitializeComponent();
        this.allToDos = allToDos;
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AddTitleBar);

        OverlappedPresenter presenter = OverlappedPresenter.Create();
        presenter.IsAlwaysOnTop = true;
        presenter.IsMaximizable = false;
        presenter.IsMinimizable = false;
        presenter.PreferredMinimumHeight = 300;
        presenter.PreferredMinimumWidth = 400;
        presenter.PreferredMaximumHeight = 600;
        presenter.PreferredMaximumWidth = 800;

        AppWindow.SetPresenter(presenter);


        
        AppWindow.Resize(new Windows.Graphics.SizeInt32(400, 300));
        
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        DateTime date = CalendarDateInput.Date?.Date ?? DateTime.Now;
        await allToDos.AddToDo(TitleTextBox.Text, BodyTextBox.Text,date);
        this.Close();
    }
}
