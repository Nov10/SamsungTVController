   M S B A M L   `   `   `  ���� M  ISchoolTVController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SchoolTVControllerSchoolTVController  &     SchoolTVController.SettingViewer   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:SchoolTVController     -     � Title$  SettingViewer��$	��450��$	��800��.��� ���	#FFA5A5A5.+���  �� CornerRadius$ 8��$��27��$��	10,31,0,0q�$	��Top=�$	��210��
�������$
��Left=�._�� $
��Left=��� -    ��Name$ AutoRefreshTimeTextBox��$
��Left=�$��19��$��
124,35,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$��87��$��12(��� $
��Left=�$��	20,36,0,0q�$
��Wrap=�$��AutoRefreshTime��$	��Top=�$��19��$	��108��$��12(��� $ 8��$��27��$��	10,73,0,0q�$	��Top=�$	��593��
�������$
��Left=�._�� $
��Left=��� -   $ TvDataFilePathTextBox��$
��Left=�$��19��$��
124,77,0,0q�$
 Wrap=�$��TvDataFilePath��$	��Top=�$	��467��$��12(��� $
��Left=�$��	16,78,0,0q�$
��Wrap=�$��TvData Path��$	��Top=�$��19��$	��108��$��12(��� $ 8��$��27��$��
10,101,0,0q�$	��Top=�$	��593��
�������$
��Left=�._�� $
��Left=��� -   $$ GroupPresetDataFilePathTextBox��$
��Left=�$��19��$��124,105,0,0q�$
 Wrap=�$��GroupPresetDataFilePath��$	��Top=�$	��467��$��12(��� $
��Left=�$��
16,106,0,0q�$
��Wrap=�$��GroupPreset Path��$	��Top=�$��19��$	��108��$��12(��� $ 8��$��27��$��
10,129,0,0q�$	��Top=�$	��593��
�������$
��Left=�._�� $
��Left=��� -   $" MasterSettingFilePathTextBox��$
��Left=�$��19��$��124,133,0,0q�$
 Wrap=�$��MasterSettingFilePath��$	��Top=�$	��467��$��12(��� $
��Left=�$��
16,134,0,0q�$
��Wrap=�$��MasterSetting Path��$	��Top=�$��19��$	��108��$��12(��� $ 8��$��27��$��
10,176,0,0q�$	��Top=�$	��593��
�������$
��Left=�._�� $
��Left=��� -   $ AccessTokenTextBox��$
��Left=�$��19��$��124,180,0,0q�$
 Wrap=�$��AccessToken��$	��Top=�$	��467��$��12(��� $
��Left=�$��
16,181,0,0q�$
��Wrap=�$��AccessToken��$	��Top=�$��19��$	��108��$��12(��� -    ��Name$ ButtonTVListReader��$��Read TV List��$
��Left=�$��
673,72,0,0q�$	��Top=�$	��102��$��25���� -   $ ButtonGroupPresetReader��$��Read Preset List��$
��Left=�$��673,103,0,0q�$	��Top=�$	��102��$��25���� -	   $ ButtonMastetSettingReader��$��Read Master Setting��$
��Left=�$��662,130,0,0q�$	��Top=�$	��113��$��25���� -
   $ TmpDataWriteButton��$��Write Tmp Data��$
��Left=�$��	673,5,0,0q�$	��Top=�$	��102��$��25���� -   $ 
SaveButton��$
��Save��$
��Left=�$��705,387,0,0q�$	��Top=�$��79��$��24��