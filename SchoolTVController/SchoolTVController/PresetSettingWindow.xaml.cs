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
using System.Xml.Linq;

namespace SchoolTVController
{
    /// <summary>
    /// Interaction logic for PresetSettingWindow.xaml
    /// </summary>
    public partial class PresetSettingWindow : Window
    {
        public PresetSettingWindow()
        {
            InitializeComponent();
        }

        GroupPreset TargetPreset;
        List<TVViewer> viewers;
        System.Action OnSave;

        GroupPreset TmpPreset;

        public void SetInfo(GroupPreset preset, List<TVViewer> list, System.Action onSave)
        {
            TargetPreset = preset;

            TmpPreset = new GroupPreset();
            TmpPreset.Name = preset.Name;
            TmpPreset.Index = preset.Index;
            //TmpPreset.DeviceIDs = new List<string>(preset.DeviceIDs);
            //TmpPreset.Names = new List<string>(preset.Names);
            TmpPreset.InstanceIDs = new List<string>(preset.InstanceIDs);

            viewers = list;
            OnSave = onSave;

            for (int i = 0; i < list.Count; i++)
            {
                Button btn = new Button();
                //btn.Tag = list[i].Data.DeviceID;
                btn.Tag = list[i].Data.InstanceID;
                btn.Content = list[i].Data.Name;
                btn.Click += TVDataButton_Click;
                btn.Height = 40;
                btn.Width = 70;
                btn.Margin = new Thickness(10, 10, 0, 0);

                //if (TmpPreset.DeviceIDs.Contains(btn.Tag))
                if (TmpPreset.InstanceIDs.Contains(btn.Tag))
                {
                    btn.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                }
                else
                {
                    btn.Background = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
                }

                ListPanel.Children.Add(btn);
            }

            string names = string.Empty;
            //for (int i = 0; i < TmpPreset.DeviceIDs.Count; i++)
            //    names += TmpPreset.Names[i] + "  ";
            for (int i = 0; i < TmpPreset.InstanceIDs.Count; i++)
            {
                if (MainWindow.Instance.FindViewerByInstanceID(TmpPreset.InstanceIDs[i], out var v))
                    names += v.Data.Name + "  ";
            }
            SelectedTVsTextBlock.Text = names;

            PresetNameTextBox.Text = TmpPreset.Name;
        }

        private void TVDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (TmpPreset == null)
                return;
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();
            if (TmpPreset.InstanceIDs.Contains(tag))
            {
                TmpPreset.InstanceIDs.Remove(tag);
                //TmpPreset.Names.Remove(btn.Content.ToString());
                btn.Background = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
            }
            else
            {
                TmpPreset.InstanceIDs.Add(tag);
                //TmpPreset.Names.Add(btn.Content.ToString());
                btn.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            }

            string names = string.Empty;
            for (int i = 0; i < TmpPreset.InstanceIDs.Count; i++)
            {
                if (MainWindow.Instance.FindViewerByInstanceID(TmpPreset.InstanceIDs[i], out var v))
                    names += v.Data.Name + "  ";
            }
            SelectedTVsTextBlock.Text = names;
        }

        private void PresetNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TmpPreset == null)
                return;
            TmpPreset.Name = PresetNameTextBox.Text;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(TmpPreset.Name == string.Empty)
            {
                string messageBoxText = $"TV의 이름을 공백으로 설정할 수 없습니다.";
                string caption = "Empty Name";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else if (MainWindow.Instance.TryFindPresetByName(TmpPreset.Name, out var v) == true)
            {
                string messageBoxText = $"같은 이름의 GroupPreset을 설정할 수 없습니다.";
                string caption = "Same Name";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                TargetPreset.Name = TmpPreset.Name;
                TargetPreset.InstanceIDs = new List<string>(TmpPreset.InstanceIDs);
                //TargetPreset.Names = new List<string>(TmpPreset.Names);
                TargetPreset.Index = TmpPreset.Index;
                OnSave?.Invoke();
                this.Hide();
                this.Close();

                TVControl.TVFileController.WriteTVGroupData(MainWindow.Instance.Presets);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = $"프리셋 '{TargetPreset.Name}'을(를) 삭제하시겠습니까?";
            string caption = "Remove Preset";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            if(result == MessageBoxResult.Yes)
            {
                MainWindow.Instance.Presets.Remove(TargetPreset);
                MainWindow.Instance.RemoveUnsedPresetViwers();
                this.Hide();
                this.Close();
            }
            TVControl.TVFileController.WriteTVGroupData(MainWindow.Instance.Presets);
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
