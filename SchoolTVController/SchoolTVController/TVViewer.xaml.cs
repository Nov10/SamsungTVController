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
using TVControl;
using System.Threading;

namespace SchoolTVController
{
    /// <summary>
    /// Interaction logic for TVViewer.xaml
    /// </summary>
    public partial class TVViewer : UserControl
    {
        public static TVViewer CreateNew(TVData data)
        {
            TVViewer viewer = new TVViewer();
            viewer.Initialize(data);
            viewer.Width = 210;
            viewer.Height = 160;
            viewer.Margin = new Thickness(20, 20, 0, 0);
            viewer.AllowDrop = true;
            return viewer;
        }

        string TargetChannel;

        public TVData Data { get; set; }
        public TVViewer()
        {
            InitializeComponent();
            //EventManager.RegisterClassHandler(typeof(TVViewer), TVViewer.MouseDoubleClickEvent, new RoutedEventHandler(OnMouseDoubleClickEvent));
        }
        public void Initialize(TVData data)
        {
            Data = data;
            Refresh();
        }
        public bool isSelected { get; private set; }
        public void Select(bool active, List<TVViewer> list)
        {
            if(active == true)
            {
                if (list.Contains(this))
                    return;
                isSelected = true;
                SelectGrid.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                list.Add(this);
            }
            else
            {
                if (list.Contains(this) == false)
                    return;
                isSelected = false;
                SelectGrid.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                list.Remove(this);
            }
            MainWindow.Instance.UpdateSelectedViewerName();
        }
        public bool isWorking = false;
        public bool isRefreshing = false;
        public TVController.TVHealth HealthState;
        public void Refresh(bool debug = true)
        {
            this.Dispatcher.Invoke(() => _Refresh(debug));
        }
        public void Refresh()
        {
            this.Dispatcher.Invoke(() => _Refresh(true));
        }
        async void _Refresh(bool debug)
        {
            try
            {
                isRefreshing = true;
                HealthState = await TVController.GetAllInfo(Data, debug);

                TVNameTextBlock.Text = Data.Name;

                if (HealthState != null)
                {
                    //TV의 이름 업데이트
                    //TV의 전원 상태 업데이트
                    string onoff = HealthState.State.ToString();
                    ONOFFTextBlock.Text = onoff;
                    if (onoff == "On")
                    {
                        //초록색
                        StateGrid.Background = new SolidColorBrush(Color.FromArgb(128, 0, 255, 0));
                    }
                    else if (onoff == "Off")
                    {
                        //검은색
                        StateGrid.Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    }
                    else
                    {
                        //빨간색
                        StateGrid.Background = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));
                    }
                    //TV의 채널 업데이트
                    ChannelTextBlock.Text = HealthState.Channel;
                    ChannelNameTextBlock.Text = HealthState.ChannelName;
                    MediaInputTextBlock.Text = HealthState.MediaInput;

                    if(AdvancedController != null)
                    {
                        AdvancedController.Refresh();
                    }
                }
                else
                {
                    ONOFFTextBlock.Text = "ERROR";
                    //빨간색
                    StateGrid.Background = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));
                    //TV의 채널 업데이트
                    ChannelTextBlock.Text = "ERROR";
                    ChannelNameTextBlock.Text = "ERROR";
                    MediaInputTextBlock.Text = "ERROR";
                }
                isRefreshing = false;
            }
            catch
            {

            }
            isRefreshing = false;
        }

        private async void OffButton_Click(object sender, RoutedEventArgs e)
        {
            if(Data != null)
            {
                await TVController.SwitchTV(Data, TVController.eState.Off);
            }
        }
        private async void OnButton_Click(object sender, RoutedEventArgs e)
        {
            if (Data != null)
            {
                await TVController.SwitchTV(Data, TVController.eState.On);
            }
        }
        private void ChannelInputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TargetChannel = ChannelInputTextBox.Text;
        }
        private async void SetTVChannelButton_Click(object sender, RoutedEventArgs e)
        {
            if (Data != null)
            {
                await TVController.ChangeTVChannel(Data, TargetChannel);
            }
        }
        private async void TVButton_Click(object sender, RoutedEventArgs e)
        {
            if (Data != null)
            {
                await TVControl.TVController.ChangeTVMediaInput(Data, "digitalTv"); //digitalTv ??
            }
        }

        //AdvancedTVControllerWindow와 TVViewerSettingWindow를 동시에 열 수 없습니다.

        public AdvancedTVControllerWindow AdvancedController;
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                //with Ctrl
                if (AdvancedController != null)
                    return;
                if (SettingWindow != null)
                    return;
                AdvancedController = new AdvancedTVControllerWindow();
                AdvancedController.Topmost = true;
                AdvancedController.SetInfo(this);
                AdvancedController.Show();
            }
            else
            {
                Select(!isSelected, MainWindow.Instance.SelectedViewers);
            }
        }
        public TVViewerSettingWindow SettingWindow;
        private void SelectButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (SettingWindow != null)
                return;
            if (AdvancedController != null)
                return;
            SettingWindow = new TVViewerSettingWindow();
            SettingWindow.Topmost = true;
            SettingWindow.SetInfo(this, Refresh);
            SettingWindow.Show();
        }
    }
}
