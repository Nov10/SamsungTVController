   M S B A M L   `   `   `  ����M  ISchoolTVController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SchoolTVControllerSchoolTVController  5   	   3    -SchoolTVController.AdvancedTVControllerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SchoolTVController     5   	   -   5          � Title$   AdvancedTVControllerWindow��5   	   $	��450��6,   $	��800��69   .��5
      � .+�5   
   � 
�������$��0,116,-0.154,-0.077q�6#   .+�5      �� -   5         ��Name$ ChannelTextBox��5      $
��Left=�6.   $��18��6I   $��	35,22,0,0q�6U    �� TextWrapping$
 Wrap=�6h   $��Channel��6|   $	��Top=�6�   $	��333��6�   �� 5      -   5         ��Name$ ChannelSetButton��5      $��Set Channel��6/   $
��Left=�6E   $��
386,22,0,0q�6`   $	��Top=�6t   $��81��6�   $��18��6�   6�   �� 5      -   5        $ MediaInputTextBox��5      $
��Left=�61   $��18��6L   $��	35,53,0,0q�6X   $
 Wrap=�6k   $��
MediaInput��6   $	��Top=�6�   $	��333��6�   �� 5      -   5        $ MediaInputSetButton��5      $��	Set Media��62   $
��Left=�6F   $��
386,53,0,0q�6a   $	��Top=�6u   $��81��6�   $��18��6�   6�   �� 5      -   5        $ 
MuteButton��5      $
��Mute��6)   $
��Left=�68   $��	35,90,0,0q�6S   $	��Top=�6f   $��75��6~   6�   �� 5      -   5        $ UnMuteButton��5      $��UnMute��6+   $
��Left=�6<   $��
125,90,0,0q�6W   $	��Top=�6k   $��75��6�   6�   �� 5      -   5         ��Name$ MediaInputTextBlock��5      $
��Left=�65   $��
481,53,0,0q�6P   $
��Wrap=�6d   $��
MediaInput��6x   $	��Top=�6�   $��69��6�   $��17��6�   �� 5      -	   5        $ MediaInputNameTextBlock��5      $
��Left=�69   $��
555,53,0,0q�6T   $
��Wrap=�6h   $��MediaInputName��6|   $	��Top=�6�   $��17��6�   $	��149��6�   5      �� 5   
   -
   5        $ TVNameTextBlock��5      $
��Left=�6-   $��	10,10,0,0q�6H   $
��Wrap=�6[   $��TVName��6o   $	��Top=�6}   $��36��6�   $	��356��6�   $��24(�6�   �� 5   
   -   5        $ TVDeviceIDTextBlock��5      $
��Left=�61   $��	10,46,0,0q�6L   $
��Wrap=�6_   $
��TVID��6s   $	��Top=�6   $��17��6�   $	��647��6�   $��14(�6�   �� 5   
   -   5        $ TVIPTextBlock��5      $
��Left=�6+   $��	10,63,0,0q�6F   $
��Wrap=�6Y   $
��TVIP��6m   $	��Top=�6y   $��17��6�   $	��647��6�   $��14(�6�   �� 5   
   -   5        $ TVDesriptionTextBlock��5      $
��Left=�63   $��	10,80,0,0q�6N   $
��Wrap=�6a   $��Description��6u   $	��Top=�6�   $��36��6�   $	��647��6�   $��14(�6�   �� 5   
   -   5        $ MuteTextBlock��5      $
��Left=�6+   $��245,208,0,0q�6F   $
��Wrap=�6[   $��	TextBlock��6o   $	��Top=�6�   5      5      