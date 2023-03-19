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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolTVController
{
    /// <summary>
    /// Interaction logic for PresetViewer.xaml
    /// </summary>
    public partial class PresetViewer : UserControl
    {
        public PresetViewer()
        {
            InitializeComponent();
        }

        public GroupPreset Preset;
        public void SetInfo(GroupPreset preset)
        {
            Preset = preset;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            PresetSettingWindow window = new PresetSettingWindow();
            window.SetInfo(Preset, MainWindow.Instance.Viewers, () =>
            {
                UpdatePresetUI();
            });
            window.Topmost = true;
            window.Show();
        }

        void UpdatePresetUI()
        {
            PresetNameTextBlock.Text = Preset.Name;
        }

        private void SelectPresetButton_Click(object sender, RoutedEventArgs e)
        {
            var viewers = MainWindow.Instance.Viewers;

            bool wasAllSelected = true;

            for(int i = 0; i < Preset.DeviceIDs.Count; i++)
            {
                if(MainWindow.FindTVViewPanelByID(Preset.DeviceIDs[i], out TVViewer viewer))
                {
                    if(viewer.isSelected == false)
                    {
                        wasAllSelected = false;
                    }
                    viewer.Select(true, MainWindow.Instance.SelectedViewers);
                }
            }

            if(wasAllSelected == true)
            {
                //전부 선택되었을 때에는, 모든 선택을 해제합니다.
                for (int i = 0; i < Preset.DeviceIDs.Count; i++)
                {
                    if (MainWindow.FindTVViewPanelByID(Preset.DeviceIDs[i], out TVViewer viewer))
                    {
                        viewer.Select(false, MainWindow.Instance.SelectedViewers);
                    }
                }
            }
        }
    }
}
