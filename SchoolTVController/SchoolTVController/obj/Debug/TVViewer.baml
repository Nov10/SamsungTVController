   M S B A M L   `   `   `  ����M  ISchoolTVController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SchoolTVControllerSchoolTVController  5      !    SchoolTVController.TVViewer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:SchoolTVController     5      $	��160��5      $	��210��5	      .��5      � -   5          �Name$  
SelectGrid��5      ���	#000000FF$	��160��66   $	��210��6C   .+�5   
   � 
�������$	��150��6"   $	��200��6/   �� 5   
   -   5         ��Name$ SelectButton��5      
�������$	��150��6:   $	��200��6G   6n   � 5   
   -   5        $  	StateGrid��5      $	��150��6"   $	��200��6/   ���	#00FF0000 J� IsHitTestVisible .  5      �� 5   
   -   5         ��Name$ TVNameTextBlock��5      $
��Left=�6-   $��	10,10,0,0q�6H   $
��Wrap=�6[   $��TV NAME��6o   $	��Top=�6~   $	��120��6�   $��23��6�   $��16(�6�   �� 5   
   -   5        $ OnButton��5      $��On��6#   $
��Left=�60   $��
115,33,0,0q�6K   $	��Top=�6_   $��75��6w   6�   �� 5   
   -   5        $ 	OffButton��5      $	��Off��6$   $
��Left=�62   $��
115,57,0,0q�6M   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $ ONOFFTextBlock��5       .  $
��Left=�6E   $��	10,33,0,0q�6`   $
��Wrap=�6s   $��ON/OFF��6�   $	��Top=�6�   �� 5   
   -   5        $ ChannelTextBlock��5       .  $
��Left=�6G   $��	10,56,0,0q�6b   $
��Wrap=�6u   $��CHANNEL��6�   $	��Top=�6�   �� 5   
   -	   5        $ ChannelNameTextBlock��5       .  $
��Left=�6K   $��	10,70,0,0q�6f   $
��Wrap=�6y   $��CHANNELNAME��6�   $	��Top=�6�   $��97��6�   $��15��6�   �� 5   
   -
   5        $ MediaInputTextBlock��5       .  $
��Left=�6J   $��
10,102,0,0q�6e   $
��Wrap=�6y   $��
MEDIAINPUT��6�   $	��Top=�6�   �� 5   
   -   5        $ TVButton��5      $��Set2 dTV��6#   $
��Left=�66   $��
115,82,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5         ��Name$ ChannelInputTextBox��5      $
��Left=�6/   $��18��6J   $��
10,122,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $��CHANNELNAME��6~   $	��Top=�6�   $��97��6�   6�   �� 5   
   -   5        $ SetTVChannelButton��5      $��Set Channel��6-   $
��Left=�6C   $��112,121,0,0q�6^   $	��Top=�6s   $��78��6�   6�   5      5      