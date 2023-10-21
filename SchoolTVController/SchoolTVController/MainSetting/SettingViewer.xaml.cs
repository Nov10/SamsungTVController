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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using TVControl;

namespace SchoolTVController
{
    /// <summary>
    /// Interaction logic for SettingViewer.xaml
    /// </summary>
    public partial class SettingViewer : Window
    {
        public SettingViewer()
        {
            InitializeComponent();
            AutoRefreshTimeTextBox.Text = (MainWindow.MasterSetting.RefreshTimeSec).ToString();
            MasterSettingFilePathTextBox.Text = MainWindow.MasterSetting.MasterSettingPath;
            TvDataFilePathTextBox.Text = MainWindow.MasterSetting.TVDataPath;
            GroupPresetDataFilePathTextBox.Text = MainWindow.MasterSetting.TVGroupPath;
            AccessTokenTextBox.Text = MainWindow.MasterSetting.AccessToken;
        }

        private void AutoRefreshTimeValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MasterSetting.RefreshTimeSec = float.Parse(AutoRefreshTimeTextBox.Text);
            MainWindow.MasterSetting.MasterSettingPath = MasterSettingFilePathTextBox.Text;
            MainWindow.MasterSetting.TVDataPath = TvDataFilePathTextBox.Text;
            MainWindow.MasterSetting.TVGroupPath = GroupPresetDataFilePathTextBox.Text;
            MainWindow.MasterSetting.AccessToken = AccessTokenTextBox.Text;
            TVControl.TVFileController.WriteMasterSettingData(MainWindow.MasterSetting);
            MainWindow.Instance.ReadMasterSetting();
            //this.Close();
        }
        private void TmpDataWriteButton_Click(object sender, RoutedEventArgs e)
        {
            List<TVData> list = new List<TVData>();
            list.Add(new TVData());
            TVControl.TVFileController.WriteTVData(list);

            List<GroupPreset> presets = new List<GroupPreset>();
            presets.Add(new GroupPreset());
            TVControl.TVFileController.WriteTVGroupData(presets);

            if (MainWindow.MasterSetting == null)
                MainWindow.MasterSetting = new Setting();
            TVControl.TVFileController.WriteMasterSettingData((MainWindow.MasterSetting));
        }
        private void ButtonTVListReader_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ReadTVList();
        }

        private void ButtonGroupPresetReader_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ReadGroupPresetList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.Instance.MasterSettingViewer = null;
        }

        public void Refresh()
        {
            AutoRefreshTimeTextBox.Text = (MainWindow.MasterSetting.RefreshTimeSec).ToString();
            MasterSettingFilePathTextBox.Text = MainWindow.MasterSetting.MasterSettingPath;
            TvDataFilePathTextBox.Text = MainWindow.MasterSetting.TVDataPath;
            GroupPresetDataFilePathTextBox.Text = MainWindow.MasterSetting.TVGroupPath;
        }

        private void ButtonMastetSettingReader_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ReadMasterSetting();
        }

        private void AccessTokenTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MainWindow.MasterSetting.AccessToken = AccessTokenTextBox.Text;
        }
    }
}
