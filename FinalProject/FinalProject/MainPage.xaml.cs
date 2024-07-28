
using FinalProject.SQLite;
using System;

using System.Collections.Generic;
using Xamarin.Forms;
using static FinalProject.SQLite.Tables;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        private bool isDarkMode = false;
        public MainPage()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ToggleDarkMode_Clicked(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme(); 
        }

        private void ApplyTheme()
        {
            if (isDarkMode)
            {
               
                this.BackgroundColor = (Color)Application.Current.Resources["BackgroundColorDark"];
                ToggleDarkModeButton.TextColor = (Color)Application.Current.Resources["ForegroundColorDark"];
                ToggleDarkModeButton.Text = "Switch to Light Mode"; 
            }
            else
            {
                
                this.BackgroundColor = (Color)Application.Current.Resources["BackgroundColorLight"];
                ToggleDarkModeButton.TextColor = (Color)Application.Current.Resources["ForegroundColorLight"];
                ToggleDarkModeButton.Text = "Switch to Dark Mode";
            }
        }
        private async void LoadApps()
        {
            try
            {
                AppList.IsRefreshing = true;
                List<NotificationApp> _AppList = await DBServices.GetAppDetails();
                AppList.ItemsSource = null;
                AppList.ItemsSource = _AppList;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load apps: {ex.Message}", "OK");
            }
            finally
            {
                AppList.IsRefreshing = false;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await SQLiteOperations.InitializeDB();
                LoadApps();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to initialize database: {ex.Message}", "OK");
            }
        }

        private async void AddApplication_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AppName.Text))
            {
                try
                {
                    await DBServices.InsertTodoApp(AppName.Text);
                    AppName.Text = string.Empty; // Clear the entry after adding
                    LoadApps();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Failed to add app: {ex.Message}", "OK");
                }
            }
            else
            {
                await DisplayAlert("Warning", "Please enter an application name.", "OK");
            }
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

