   M S B A M L   `   `   `  ����  SpotifyCSharp    SpotifyCSharp.player   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � -   5          �Name$  PlayerViewGrid��5      
�������.+�5	   
   �� -   5         ��Name$ AlbumImg��5	      $	��Top=�6"   $
��Left=�6:   $��	10,10,0,0q�6U   $��75��6h   $��75��6t   �� 5
   
   -   5         ��Name$ 	LblArtist��5
      $��100,23,560,50q�6#   �� 5   
   -   5         ��Name$ LblSong��5       �� TextAlignment$
 Left=�6%   $��
100,53,0,0q�6:   $
��Wrap=�6N   $	��Top=�6b   $
��Bold"�6z   $
��Left=�6�   $	��140��6�   �� 5   
   -   5        $ PreviousImg��5      $
��Left=�6%   $��30��6@   $��
401,22,0,0q�6L   $	��Top=�6`   $��30��6x   $��/Images/previous.png��6�   6�   �� 5   
   -   5        $ SkipImg��5      $
��Left=�6!   $��30��6<   $��
476,22,0,0q�6H   $	��Top=�6\   $��30��6t   $��/Images/skip.png��6   6�   �� 5   
   -   5        $ PlayPauseImg��5      $��30��6&   $��30��62   $
��Left=�6=   $	��Top=�6X   $��
441,22,0,0q�6p   $��/Images/play.png��6�   �� 5   
   -   5        $ LblStartTime��5      $
��Left=�6&   $��00:00��6A   $��263,55,931,18q�6Q   �� 5   
   -	   5        $ 
LblEndTime��5      $
��Left=�6$   $��00:00��6?   $��630,55,0,18q�6O   z�5      V� 5      .~�5      ��  �� ScaleX$ 1Q�6%   �� 5      �� 5      T� 5      5      5      �� 5   
   -
   5        $ 
ShuffleImg��5      $��30��6$   $��30��60   $��
361,22,0,0q�6;   $
��Left=�6O   $	��Top=�6j   $��/Images/shuffle-off.png��6�   6�   �� 5   
   -   5        $ 	RepeatImg��5      $��30��6#   $��30��6/   $��/Images/repeat-off.png��6:   $��
516,22,0,0q�6Z   $
��Left=�6n   $	��Top=�6�   6�   �� 5   
   -   5        $ VolImg��5      $��30��6    $��30��6,   $��	0,0,350,0q�67   $��Right=�6J   $��Center=�6f   6�   �� 5   
   -   5         ��Name$ VolumeSlider��5      $��Right=�6'   $��	0,0,150,0q�6C   $��Center=�6V   $	��200��6q    � Maximum$	 100Q�6}    � SmallChange$ 1Q�6�   	 � Value$	 66Q�6�   
 �� TickPlacement$

 None=�6�   �� 5   
   -   5        $ 
TimeSlider��5      $
��Left=�6T   $��
319,60,0,0q�6o   $	��Top=�6�   $	��300��6�   $ 1Q�6�   5      5       