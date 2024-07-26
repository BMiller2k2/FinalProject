
using FinalProject.SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static FinalProject.SQLite.Tables;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void LoadItems()
        {
            ItemList.IsRefreshing = true;
            List<ToDoItem> _ItemList = DBServices.GetItemDetails().Result;
            ItemList.ItemsSource = null;
            ItemList.ItemsSource = _ItemList;
            ItemList.IsRefreshing = false;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await SQLiteOperations.InitializeDB();
            LoadItems();
        }

        async void AddItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await DBServices.InsertTodoItem(ItemName.Text);
            ItemName.Text = "";
            LoadItems();
        }
        private void OnEnableNotificationsClicked(object sender, EventArgs e)
        {
            // Enable notifications
            StatusLabel.Text = "Notifications Enabled.";
            // Implement the code to enable notifications here
        }

        private void OnDisableNotificationsClicked(object sender, EventArgs e)
        {
            // Disable notifications
            StatusLabel.Text = "Notifications Disabled.";
            // Implement the code to disable notifications here
        }

       
    }
}
