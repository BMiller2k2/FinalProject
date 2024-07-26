
using System;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
