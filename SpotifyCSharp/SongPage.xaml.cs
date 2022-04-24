﻿using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for SongPage.xaml
    /// </summary>
    public partial class SongPage : Page, TableViewDelegate, TableViewDatasource
    {
        private List<FullTrack> songs;
        private player player_controller;
        public SongPage(List<FullTrack> Songs, player PlayerController)
        {
            InitializeComponent();
            this.player_controller = PlayerController;
            songs = Songs;
            SongTableView.Delegate = this;
            SongTableView.Datasource = this;
            SongTableView.Refresh();
        }

        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath)
        {
            SongTableViewCell Cell = new SongTableViewCell(IndexPath);
            FullTrack Song = songs[IndexPath.Row];
            Cell.SongLabel.Text = Song.Name;
            Cell.ArtistLabel.Text = Song.Artists[0].Name;
            Cell.AlbumImage.Source = GetImage(Song.Album.Images[0].Url);
            return Cell;
        }

        // Helper method that returns an BitmapImage from a URL. 
        private BitmapImage GetImage(string URL)
        {
            BitmapImage Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            Bitmap.UriSource = new Uri(URL);
            Bitmap.EndInit();
            return Bitmap;
        }
        public int NumberOfRowsInSection(TableView TableView, int Section)
        {
            return songs.Count;
        }
    }
}
