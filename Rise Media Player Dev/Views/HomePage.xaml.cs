﻿using Rise.App.Dialogs;
using Rise.App.Web;
using Rise.Common.Extensions;
using Rise.Common.Helpers;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Rise.App.Views
{
    public sealed partial class HomePage : Page
    {
        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        private readonly NavigationHelper _navigationHelper;

        public HomePage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;

            _navigationHelper = new NavigationHelper(this);
        }

        private async void SupportButton_Click(object sender, RoutedEventArgs e)
        {
            _ = await typeof(SupportProject).
                ShowInApplicationViewAsync(null, 500, 600, true);
        }

        private async void WhatsNew_Click(object sender, RoutedEventArgs e)
        {
            _ = await typeof(WhatsNew).
                ShowInApplicationViewAsync(null, 500, 600, true);
        }

        private async void FoldersButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new()
            {
                Title = "Manage local media folders",
                CloseButtonText = "Close",
                Content = new Settings.MediaSourcesPage()
            };

            var result = await dialog.ShowAsync();
        }

        private async void GlanceManage_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new()
            {
                CloseButtonText = "Close",
                DefaultButton = ContentDialogButton.Primary,
                Content = new WidgetsDialogContent()
            };

            var result = await dialog.ShowAsync();
        }

        #region NavigationHelper registration
        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
            => _navigationHelper.OnNavigatedTo(e);

        protected override void OnNavigatedFrom(NavigationEventArgs e)
            => _navigationHelper.OnNavigatedFrom(e);
        #endregion
    }
}