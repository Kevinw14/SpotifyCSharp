﻿#pragma checksum "..\..\..\player.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65D5078B05098EF12909A56B87EE76CD2CD82A7D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SpotifyCSharp {
    
    
    /// <summary>
    /// player
    /// </summary>
    public partial class player : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PlayerViewGrid;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image AlbumImg;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblArtist;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LblSong;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PreviousImg;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SkipImg;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PlayPauseImg;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblStartTime;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblEndTime;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ShuffleImg;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image RepeatImg;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image VolImg;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider VolumeSlider;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider TimeSlider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SpotifyCSharp;component/player.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\player.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PlayerViewGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.AlbumImg = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.LblArtist = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.LblSong = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.PreviousImg = ((System.Windows.Controls.Image)(target));
            
            #line 12 "..\..\..\player.xaml"
            this.PreviousImg.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.PreviousImg_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SkipImg = ((System.Windows.Controls.Image)(target));
            
            #line 13 "..\..\..\player.xaml"
            this.SkipImg.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SkipImg_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PlayPauseImg = ((System.Windows.Controls.Image)(target));
            
            #line 14 "..\..\..\player.xaml"
            this.PlayPauseImg.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.PlayPauseImg_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LblStartTime = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.LblEndTime = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.ShuffleImg = ((System.Windows.Controls.Image)(target));
            
            #line 26 "..\..\..\player.xaml"
            this.ShuffleImg.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ShuffleImg_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.RepeatImg = ((System.Windows.Controls.Image)(target));
            
            #line 27 "..\..\..\player.xaml"
            this.RepeatImg.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.RepeatImg_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.VolImg = ((System.Windows.Controls.Image)(target));
            
            #line 28 "..\..\..\player.xaml"
            this.VolImg.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.VolImg_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 13:
            this.VolumeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 29 "..\..\..\player.xaml"
            this.VolumeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.VolumeSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.TimeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 30 "..\..\..\player.xaml"
            this.TimeSlider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.TimeSlider_DragCompleted));
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

