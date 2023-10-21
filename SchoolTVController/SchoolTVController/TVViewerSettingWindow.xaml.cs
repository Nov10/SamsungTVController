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
using TVControl;

namespace SchoolTVController
{
    /// <summary>
    /// Interaction logic for TVViewerSettingWindow.xaml
    /// </summary>
    public partial class TVViewerSettingWindow : Window
    {
        public TVViewerSettingWindow()
        {
            InitializeComponent();
        }
        TVViewer TargetViewer;
        TVData TmpData;
        TVData TargetData;
        System.Action OnSave;
        public void SetInfo(TVViewer viewer, System.Action onSave)
        {
            TargetViewer = viewer;
            TargetData = viewer.Data;

            TmpData = new TVData();
            TmpData = new TVControl.TVData();
            TmpData.Name = viewer.Data.Name;
            TmpData.DeviceID = viewer.Data.DeviceID;
            TmpData.IP = viewer.Data.IP;
            TmpData.Description = viewer.Data.Description;

            TVNameTextBox.Text = TargetViewer.Data.Name;
            DeviceIDTextBox.Text = TargetViewer.Data.DeviceID;
            IPTextBox.Text = TargetViewer.Data.IP;
            DescriptionTextBox.Text = TargetViewer.Data.Description;

            OnSave = onSave;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = $"TV '{TargetViewer.Data.Name}'을(를) 삭제하시겠습니까?";
            string caption = "Remove Preset";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow.Instance.Viewers.Remove(TargetViewer);
                MainWindow.Instance.RemoveUnsedTVViwers();
                MainWindow.Instance.ValidatePresets(MainWindow.Instance.Presets);

                TVFileController.WriteTVGroupData(MainWindow.Instance.Presets);
                this.Hide();
                this.Close();
            }
            TVControl.TVFileController.WriteTVData(MainWindow.Instance.Viewers);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeviceIDTextBox.Text == string.Empty)
            {
                string messageBoxText = $"TV의 DeviceID를 공백으로 설정할 수 없습니다.";
                string caption = "Empty DeviceID";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            if (TVNameTextBox.Text == string.Empty)
            {
                string messageBoxText = $"TV의 이름을 공백으로 설정할 수 없습니다.";
                string caption = "Empty Name";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else if (MainWindow.Instance.IsViewerExistDeviceID(DeviceIDTextBox.Text, out string tvName) == true && tvName != TargetData.Name)
            {
                string messageBoxText = $"같은 DeviceID의 TV를 설정할 수 없습니다. '{tvName}'와 겹칩니다.";
                string caption = "Same DeviceID";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else if (MainWindow.Instance.IsViewerExistName(TVNameTextBox.Text, out tvName) == true && tvName != TargetData.Name)
            {
                string messageBoxText = $"같은 이름의 TV를 설정할 수 없습니다. '{tvName}'와 겹칩니다.";
                string caption = "Same Name";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                TargetViewer.Data.Name = TmpData.Name = TVNameTextBox.Text;
                TargetViewer.Data.DeviceID = TmpData.DeviceID = DeviceIDTextBox.Text;
                TargetViewer.Data.IP = TmpData.IP = IPTextBox.Text;
                TargetViewer.Data.Description = TmpData.Description = DescriptionTextBox.Text;

                OnSave?.Invoke();
                this.Hide();
                this.Close();

                TVControl.TVFileController.WriteTVData(MainWindow.Instance.Viewers);
                OnSave?.Invoke();
            }
        }

        private void TVNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            TargetViewer.SettingWindow = null;
        }

        private void DeviceIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
