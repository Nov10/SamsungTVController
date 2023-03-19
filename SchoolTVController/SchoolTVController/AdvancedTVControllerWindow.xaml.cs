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
using System.Threading;

namespace SchoolTVController
{
    /// <summary>
    /// Interaction logic for AdvancedTVControllerWindow.xaml
    /// </summary>
    public partial class AdvancedTVControllerWindow : Window
    {
        public AdvancedTVControllerWindow()
        {
            InitializeComponent();
        }
        TVViewer Viewer;
        public void SetInfo(TVViewer viewer)
        {
            Viewer = viewer;
            TVNameTextBlock.Text = Viewer.Data.Name;
            TVDeviceIDTextBlock.Text = Viewer.Data.DeviceID;
            TVIPTextBlock.Text = Viewer.Data.IP;
            TVDesriptionTextBlock.Text = Viewer.Data.Description;

            ChannelTextBox.Text = Viewer.HealthState?.Channel;
            MediaInputTextBox.Text = Viewer.HealthState?.MediaInput;
            Refresh();
        }

        

        private async void ChannelSetButton_Click(object sender, RoutedEventArgs e)
        {
            await TVControl.TVController.ChangeTVChannel(Viewer.Data, ChannelTextBox.Text);
        }

        private async void MediaInputSetButton_Click(object sender, RoutedEventArgs e)
        {
            await TVControl.TVController.ChangeTVMediaInput(Viewer.Data, MediaInputTextBox.Text);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Viewer.AdvancedController = null;
        }

        private async void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            await TVControl.TVController.ChangeTVMute(Viewer.Data, true);
        }

        private async void UnMuteButton_Click(object sender, RoutedEventArgs e)
        {
            await TVControl.TVController.ChangeTVMute(Viewer.Data, false);
        }

        public void Refresh()
        {
            MuteTextBlock.Text = Viewer.HealthState?.Mute == true ? "muted" : "unmuted";
            MediaInputNameTextBlock.Text = Viewer.HealthState?.MediaInputName;
            MediaInputTextBlock.Text = Viewer.HealthState?.MediaInput;
        }
    }
}
