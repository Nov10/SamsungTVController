   M S B A M L   `   `   `  ���� M  ISchoolTVController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SchoolTVControllerSchoolTVController  !    SchoolTVController.TVViewer   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:SchoolTVController     $	��160��$	��210��.��� -     �Name$  
SelectGrid�����	#000000FF$	��160��$	��210��.+�� 
�������$	��150��$	��200���� -    ��Name$ SelectButton��
�������$	��150��$	��200��� -   $  	StateGrid��$	��150��$	��200�����	#00FF0000 J� IsHitTestVisible .  �� -    ��Name$ TVNameTextBlock��$
��Left=�$��	10,10,0,0q�$
��Wrap=�$��TV NAME��$	��Top=�$	��120��$��23��$��16(��� -   $ OnButton��$��On��$
��Left=�$��
115,33,0,0q�$	��Top=�$��75���� -   $ 	OffButton��$	��Off��$
��Left=�$��
115,57,0,0q�$	��Top=�$��75���� -   $ ONOFFTextBlock�� .  $
��Left=�$��	10,33,0,0q�$
��Wrap=�$��ON/OFF��$	��Top=��� -   $ ChannelTextBlock�� .  $
��Left=�$��	10,56,0,0q�$
��Wrap=�$��CHANNEL��$	��Top=��� -	   $ ChannelNameTextBlock�� .  $
��Left=�$��	10,70,0,0q�$
��Wrap=�$��CHANNELNAME��$	��Top=�$��97��$��15���� -
   $ MediaInputTextBlock�� .  $
��Left=�$��
10,102,0,0q�$
��Wrap=�$��
MEDIAINPUT��$	��Top=��� -   $ TVButton��$��Set2 dTV��$
��Left=�$��
115,82,0,0q�$	��Top=�$��75���� -    ��Name$ ChannelInputTextBox��$
��Left=�$��18��$��
10,122,0,0q� �� TextWrapping$
 Wrap=�$��CHANNELNAME��$	��Top=�$��97���� -   $ SetTVChannelButton��$��Set Channel��$
��Left=�$��112,121,0,0q�$	��Top=�$��78��