using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for player.xaml
    /// </summary>
    public partial class player : UserControl
    {
        public player()
        {
            InitializeComponent();
        }

        private void PlayPauseImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if source img is play.png
                //change source img to pause.png
                //pause song
            //else
                //change source img to play.png
                //play song
        }

        private void ShuffleImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //boolean to see if shuffle is already on
            //if not turn on shuffle and highlight box?
            //else turn off shuffle and un-highlight box
        }

        private void SkipImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Change to next track
        }

        private void PreviousImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Restart Track for single click

            //not sure how to implement double click
        }

        private void VolImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if song is not muted
                //mute song
            //else
                //unmute song
        }

        private void InfoImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //here we could have a pop up with add to playlist, queue, etc?? Maybe
        }

        private void RepeatImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //again depending on what img is the source on click, will change to other image and change repeat
        }
    }
}
