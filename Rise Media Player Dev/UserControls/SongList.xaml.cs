﻿using RMP.App.ViewModels;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RMP.App.UserControls
{
    public sealed partial class SongList : UserControl
    {
        /// <summary>
        /// Gets the app-wide MViewModel instance.
        /// </summary>
        private MainViewModel MViewModel => App.MViewModel;

        /// <summary>
        /// Gets the app-wide NPViewModel instance.
        /// </summary>
        private static PlaybackViewModel PViewModel => App.PViewModel;

        public SongList()
        {
            InitializeComponent();
            Loaded += SongList_Loaded;

            DataContext = MViewModel;
        }

        public DataTemplate Header { get; set; }
        public ObservableCollection<SongViewModel> List { get; set; }

        private void SongList_Loaded(object sender, RoutedEventArgs e)
        {
            if (Header == null)
            {
                MainList.Margin = new Thickness(-56, 0, -56, 0);
                return;
            }

            MainList.HeaderTemplate = Header;
        }

        private async void MainList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            int itemIndex = MainList.SelectedIndex;

            if (itemIndex < 0)
            {
                return;
            }

            PViewModel.CancelTask();
            await PViewModel.CreatePlaybackList(itemIndex, List, PViewModel.Token);
        }

        private void MainList_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            MViewModel.SelectedSong = (e.OriginalSource as FrameworkElement).DataContext as SongViewModel;
        }

        private async void Props_Click(object sender, RoutedEventArgs e)
        {
            await MViewModel.SelectedSong.StartEdit();
        }
    }
}