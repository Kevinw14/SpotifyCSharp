   M S B A M L   `   `   `  ����H  DSpotifyCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SpotifyCSharpSpotifyCSharp  5   	       SpotifyCSharp.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SpotifyCSharp     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1250��6)   $	��720��5	   	   $
��1250��6   .��5
      � .+�5   
   �� -   5         ��Name$ UserGroupBox��5      $
��Left=�6)   $	��Top=�6D   $
��User��6\   $��20,0,0,0q�6j   $	��112��6|   $	��250��6�   .��5      � $��0,0,-2,0q�6   .+�5      �� -   5         ��Name$ LoginButton��5      $��Login��6.   $��Center=�6>   $��0,0,0,0q�6[   $��Center=�6l   6�   �� 5      -   5        $ LogoutButton��5      $��Logout��6/   $��Center=�6@   $��0,0,0,0q�6]   $��Center=�6n   $y�Hidden=�6�   �� 5      -   5         ��Name$ ProfileImage��5      $
��Left=�6.   $��48��6I   $��20,0,0,0q�6U   $��Center=�6g   $��48��6�   $y�Hidden=�6�   5      5      �� 5   
   -   5        $ SearchGroupBox��5      $��Search��6+   $��285,0,587,646q�6;   .��5      � $��84��6   $��	0,0,-12,0q�6   .+�5      �� -   5         ��Name$ SearchTextField��5      $	��Top=�63   $��
10,10,10,0q�6K    �� TextWrapping$
 Wrap=�6_   ${�False��6s   	� 5      -   5         	�Name$ SongRadioButton��5      $��Songs��67   $
��Left=�6G   $��	10,68,0,0q�6b   $	��Top=�6u   $��56��6�    	� 	GroupName$ 
SearchType��6�    d� 	IsChecked$
 TrueY�6�   $��16��6�   �� 5      -   5        $ SearchButton��5      $��Search��6/   $��Stretch=�6@   $��0,40,0,0q�6^   $	��Top=�6p   $	��160��6�   ${�False��6�   	� 5      -	   5        $ AlbumRadioButton��5      $��Albums��68   $
��Left=�6I   $��
150,68,0,0q�6d   $��60��6x   $	��Top=�6�   $ 
SearchType��6�   $��16��6�   	� 5      -
   5        $ ArtistRadioButton��5      $��Artists��69   $
��Left=�6K   $��
290,68,0,0q�6f   $��60��6z   $	��Top=�6�   $ 
SearchType��6�   $��16��6�   5      5       � 5   
   -   5        	  �Name$	 	MainFrame��5      $�� ��6#   $��0,143,0,105q�6.      SpotifyCSharp.player  5   
   -   5        
  Name$
 PlayerController��5      $��Stretch=�61   $��Bottom=�6O   $��0,0,0,0q�6j   5      5       