   M S B A M L   `   `   `  ���� M  ISchoolTVController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SchoolTVControllerSchoolTVController  #    SchoolTVController.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:SchoolTVController     $
��1920��$
��1080��  � Title$  
MainWindow��$
��1080��$
��1920��.��� 
�������.+�� $��375,210,59,51q�.+��� $��Visible=�$��Disabled=�.��� -    �Name$ TVViewPanel�����	#FFBBBBBB�� -    ��Name$ TVCreateButton��$��
Create New��$��	0,0,79,59q�$��Right=�$	��106��$��38��$��Bottom=��� -   $ ButtonRefresh��$��Refresh��$
��Left=�$��	62,17,0,0q�$	��Top=�$��94��$��25��� ���	#FFBBBBBB$��
10,210,0,0q�$
��Left=�$	��338��$	��300��$	��Top=�.+��� -    ��Name$ GroupChannelNameTextBox��$
��Left=�$��21��$��
141,69,0,0q� �� TextWrapping$
 Wrap=�$��Channel Name��$	��Top=�$	��167��$��14(���  �� TextAlignment$ Center=�$
��Wrap=�$��Group Setting��$	��Top=�
�������$��30��$��20(�$	��157��$��Center=�$��
88,10,87,0q��� $
��Left=�$��	27,69,0,0q�$
��Wrap=�$��Channel Name��$	��Top=�
�������$��21��$	��123��$��16(��� $
��Left=�$��	38,96,0,0q�$
��Wrap=�$��Set Channel��$	��Top=�
�������$��21��$��92��$��16(��� -   $ GroupChannelSetButton��$��Set Channel��$
��Left=�$��
141,95,0,0q�$	��Top=�$	��167��$��28���� $
��Left=�$��
60,185,0,0q�$
��Wrap=�$��Switch��$	��Top=�
�������$��21��$��51��$��16(�$��2���� -   $ GroupOnButton��$��On��$
��Left=�$��141,166,0,0q�$	��Top=�$	��167��$��28���� -   $ GroupOffButton��$	��Off��$
��Left=�$��141,199,0,0q�$	��Top=�$	��167��$��28��$��2���� $
��Left=�$��19,242,0,-4q�$
��Wrap=�$��Set to DigitalTV��$	��Top=�
�������$��21��$	��111��$��16(��� -   $ GroupSet2TVButton��$��Set to DigitalTV��$
��Left=�$��141,241,0,-10q�$	��Top=�$	��167��$��28���� $��Visible=�$��Disabled=�$��10,546,0,51q�$
��Left=�$	��338��.��� ���	#FFBBBBBB.+��� -	    ��Name$ GroupPresetStackPanel�� �� Orientation$ Vertical=�$��	0,10,0,49q� J� 	AllowDrop . �� -
   	 ��Name$ 	 SelectedGroupListTextBlock��$
��Left=�$��375,186,0,0q�$
��Wrap=�$��
Selected: ��$	��Top=�$��24��$
��1486��$��16(��� -   $ GroupPresetCreateButton��$��
Create New��$��
245,0,0,58q�$
��Left=�$��80��$��39��$��Bottom=��� -   $ AllSelectButton��$��
Select All��$
��Left=�$��
62,173,0,0q�$	��Top=�$��94��$��24���� -   $ AllUnSelectButton��$��UnSelect All��$
��Left=�$��174,173,0,0q�$	��Top=�$	��102��$��24���� -   $ SettingButton��$��Settings��$��	0,33,67,0q�$��20��$	��Top=�$��Right=�$��75���� -   $	 RefreshTimerTextBlock��$
��Left=�$��
174,21,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�