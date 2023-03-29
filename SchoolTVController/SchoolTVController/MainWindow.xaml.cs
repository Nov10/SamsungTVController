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
using System.Windows.Threading;
using System.Runtime;
using System.Runtime.InteropServices;

namespace SchoolTVController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Instance = this;
            Viewers = new List<TVViewer>();
            SelectedViewers = new List<TVViewer>();
            Presets = new List<GroupPreset>();
            PresetViewers = new List<PresetViewer>();

            MasterSetting = new Setting();
            MasterSetting = TVFileController.ReadMasterSettingData();

            ReadTVList();

            //var groupPresets = TVFileController.ReadTVGroupData();
            //Presets = groupPresets;
            ReadGroupPresetList();
            this.Dispatcher.Invoke(() => AutoRefresh());
        }



        public static MainWindow Instance;

        public List<TVViewer> Viewers;
        public List<TVViewer> SelectedViewers;

        public List<GroupPreset> Presets;
        List<PresetViewer> PresetViewers;

        #region Main Panel(TV WrapPanel)

        public void UpdateSelectedViewerName()
        {
            string names = string.Empty;
            for(int i = 0; i < SelectedViewers.Count; i++)
            {
                names += SelectedViewers[i].Data.Name + "  ";
            }
            SelectedGroupListTextBlock.Text = "Selected: " + names;
        }
        private void TVCreateButton_Click(object sender, RoutedEventArgs e)
        {
            TVViewer viewer = TVViewer.CreateNew(new TVData());
            Viewers.Add(viewer);
            TVViewPanel.Children.Add(viewer);
        }

        //Change Index
        TVViewer Mover;
        private void TVViewPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Mover = e.Source as TVViewer;
            if (Mover != null)
                DragDrop.DoDragDrop(Mover, Mover, DragDropEffects.Move);
        }
        private void TVViewPanel_Drop(object sender, DragEventArgs e)
        {
            TVViewer newPositionViewer = e.Source as TVViewer;
            if (newPositionViewer != null && newPositionViewer != Mover)
            {
                int where_to_drop = TVViewPanel.Children.IndexOf(newPositionViewer);
                int preMoverPosition = TVViewPanel.Children.IndexOf(Mover);

                TVViewPanel.Children.Remove(Mover);
                TVViewPanel.Children.Insert(where_to_drop, Mover);

                //TVViewPanel.Children.Remove(newPositionViewer);
                //TVViewPanel.Children.Insert(preMoverPosition, newPositionViewer);

                for (int i = 0; i < TVViewPanel.Children.Count; i++)
                {
                    TVViewer view = (TVViewer)TVViewPanel.Children[i];
                    view.Data.Index = i;
                }
                SortViewersByIndex();
                TVFileController.WriteTVData(Viewers);
            }
        }

        public void RemoveUnsedTVViwers()
        {
            for (int i = 0; i < TVViewPanel.Children.Count; i++)
            {
                int index = FindViewer(TVViewPanel.Children[i]);
                if (index == -1)
                {
                    TVViewPanel.Children.RemoveAt(i);
                    i--;
                }
            }
        }
        int FindViewer(UIElement viewer)
        {
            for (int i = 0; i < Viewers.Count; i++)
            {
                if (viewer == Viewers[i])
                    return i;
            }
            return -1;
        }
        public bool FindViewerByInstanceID(string instanceID, out TVViewer viewer)
        {
            for (int i = 0; i < Viewers.Count; i++)
            {
                if (instanceID == Viewers[i].Data.InstanceID)
                {
                    viewer = Viewers[i];
                    return true;
                 }
            }
            viewer = null;
            return false;
        }

        public bool IsViewerExistDeviceID(string id, out string tvName)
        {
            for (int i = 0; i < Viewers.Count; i++)
            {
                if (Viewers[i].Data.DeviceID == id)
                {
                    tvName = Viewers[i].Data.Name;
                    return true;
                }
            }
            tvName = string.Empty;
            return false;
        }
        public bool IsViewerExistName(string name, out string tvName)
        {
            for (int i = 0; i < Viewers.Count; i++)
            {
                if (Viewers[i].Data.Name == name)
                {
                    tvName = Viewers[i].Data.Name;
                    return true;
                }
            }
            tvName = string.Empty;
            return false;
        }
        public static bool FindTVViewPanel(TVData data, out TVViewer result)
        {
            TVViewer viewer;
            UIElementCollection panel = Instance.TVViewPanel.Children;
            for (int i = 0; i < panel.Count; i++)
            {
                viewer = (TVViewer)panel[i];
                if (viewer != null)
                {
                    if (viewer.Data.DeviceID == data.DeviceID)
                    {
                        result = viewer;
                        return true;
                    }
                }
            }
            result = null;
            return false;
        }
        public static bool FindTVViewPanelByID(string deviceID, out TVViewer result)
        {
            TVViewer viewer;
            UIElementCollection panel = Instance.TVViewPanel.Children;
            for (int i = 0; i < panel.Count; i++)
            {
                viewer = (TVViewer)panel[i];
                if (viewer != null)
                {
                    if (viewer.Data.DeviceID == deviceID)
                    {
                        result = viewer;
                        return true;
                    }
                }
            }
            result = null;
            return false;
        }

        #endregion

        #region Refresh

        public bool stopAutoRefresh = false;
        System.Diagnostics.Stopwatch watch;
        void RefreshAll()
        {
            for (int i = 0; i < Viewers.Count; i++)
            {
                Viewers[i].Refresh();
            }
        }
        async void AutoRefresh()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += AutoRefresTimer_Tick;
            timer.Start();
            watch = new System.Diagnostics.Stopwatch();

        START:;

            if (stopAutoRefresh == true)
            {
                stopAutoRefresh = false;
                goto END;
            }
            watch.Reset();
            watch.Start();
            timer.Start();
            await Task.Delay((int)(MasterSetting.RefreshTimeSec * 1000));
            timer.Stop();
            watch.Stop();
            for (int i = 0; i < Viewers.Count; i++)
            {
                if (Viewers[i].isRefreshing == false && Viewers[i].isWorking == false)
                {
                    Viewers[i].Refresh(false);
                }
            }
            for (int i = 0; i < Viewers.Count; i++)
            {
                if (Viewers[i].isRefreshing == true)
                {
                    RefreshTimerTextBlock.Text = "Refreshing" + GetRefreshDot();
                    await Task.Delay(100);
                    i--;
                }
            }

            Console.WriteLine("Refresh! " + DateTime.Now.ToString("HH:mm:ss tt"));
            goto START;

        END:;
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshAll();
        }
        private void AutoRefresTimer_Tick(object sender, EventArgs e)
        {
            RefreshTimerTextBlock.Text = watch.Elapsed.ToString("ss");
        }

        int RefreshDotCount = 0;
        string GetRefreshDot()
        {
            RefreshDotCount++;
            switch (RefreshDotCount)
            {
                case 0:
                    return "";
                case 1:
                    return ".";
                case 2:
                    return "..";
                case 3:
                    RefreshDotCount = 0;
                    return "...";
            }
            return "...";
        }

        #endregion

        #region Group Panel

        string GroupChannelName;
        private void GroupOnButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedViewers == null)
                return;
            for (int i = 0; i < SelectedViewers.Count; i++)
            {
                this.Dispatcher.Invoke(() => TVController.SwitchTV(SelectedViewers[i].Data, TVController.eState.On));
            }
        }
        private void GroupOffButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedViewers == null)
                return;
            for (int i = 0; i < SelectedViewers.Count; i++)
            {
                this.Dispatcher.Invoke(() => TVController.SwitchTV(SelectedViewers[i].Data, TVController.eState.Off));
            }
        }
        private void GroupChannelNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedViewers == null)
                return;
            GroupChannelName = GroupChannelNameTextBox.Text;
            for (int i = 0; i < SelectedViewers.Count; i++)
            {
                SelectedViewers[i].ChannelInputTextBox.Text = GroupChannelName;
            }
        }
        private void GroupChannelSetButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedViewers == null)
                return;
            for (int i = 0; i < SelectedViewers.Count; i++)
            {
                this.Dispatcher.Invoke(() => TVController.ChangeTVChannel(SelectedViewers[i].Data, GroupChannelName));
            }
        }
        private void GroupSet2TVButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedViewers == null)
                return;
            for (int i = 0; i < SelectedViewers.Count; i++)
            {
                this.Dispatcher.Invoke(() => TVController.ChangeTVMediaInput(SelectedViewers[i].Data, "digitalTv"));
            }
        }
        private void AllSelectButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Viewers.Count; i++)
            {
                Viewers[i].Select(true, SelectedViewers);
            }
        }
        private void AllUnSelectButton_Click(object sender, RoutedEventArgs e)
        {
            TVViewer original;
            bool preSelected;
            for (int i = 0; i < SelectedViewers.Count; i++)
            {
                original = SelectedViewers[i];
                preSelected = SelectedViewers[i].isSelected;

                SelectedViewers[i].Select(false, SelectedViewers);
                if (preSelected != original.isSelected)
                {
                    //다른 상태 -> 선택이 해제됨
                    i--;
                }
            }
        }

        #endregion

        #region Preset Panel

        PresetViewer PresetMover;
        private void GroupPresetStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PresetMover = e.Source as PresetViewer;
            if (PresetMover != null)
                DragDrop.DoDragDrop(PresetMover, PresetMover, DragDropEffects.Move);
        }
        private void GroupPresetStackPanel_Drop(object sender, DragEventArgs e)
        {
            PresetViewer newPositionViewer = e.Source as PresetViewer;
            if (newPositionViewer != null && newPositionViewer != PresetMover)
            {
                int where_to_drop = GroupPresetStackPanel.Children.IndexOf(newPositionViewer);
                int preMoverPosition = GroupPresetStackPanel.Children.IndexOf(PresetMover);

                GroupPresetStackPanel.Children.Remove(PresetMover);
                GroupPresetStackPanel.Children.Insert(where_to_drop, PresetMover);

                GroupPresetStackPanel.Children.Remove(newPositionViewer);
                GroupPresetStackPanel.Children.Insert(preMoverPosition, newPositionViewer);

                Presets.Clear();
                for (int i = 0; i < GroupPresetStackPanel.Children.Count; i++)
                {
                    PresetViewer view = (PresetViewer)GroupPresetStackPanel.Children[i];
                    Presets.Add(view.Preset);
                }
                TVFileController.WriteTVGroupData(Presets);
            }
        }
        public void ValidatePresets(List<GroupPreset> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                for (int k = 0; k < data[i].InstanceIDs.Count; k++)
                {
                    if (MainWindow.Instance.FindViewerByInstanceID(data[i].InstanceIDs[k], out var v) == false)
                    {
                        data[i].InstanceIDs.RemoveAt(k);
                        k--;
                    }
                }
            }
        }

        private void GroupPresetCreateButton_Click(object sender, RoutedEventArgs e)
        {
            GroupPreset preset = new GroupPreset();
            Presets.Add(preset);
            var v = CreateGroupPresetViewer(preset);
            GroupPresetStackPanel.Children.Add(v);
            PresetViewers.Add(v);
            TVFileController.WriteTVGroupData(Presets);
        }
        PresetViewer CreateGroupPresetViewer(GroupPreset preset)
        {
            PresetViewer viewer = new PresetViewer();
            viewer.Width = 300;
            viewer.Height = 50;
            viewer.SetInfo(preset);
            viewer.Margin = new Thickness(0, 0, 0, 10);
            viewer.PresetNameTextBlock.Text = preset.Name;
            return viewer;
        }
        public void RemoveUnsedPresetViwers()
        {
            for(int i = 0; i < PresetViewers.Count; i++)
            {
                int index = FindPreset(PresetViewers[i]);
                if(index == -1)
                {
                    GroupPresetStackPanel.Children.Remove(PresetViewers[i]);
                    PresetViewers.RemoveAt(i);
                    i--;
                }
            }
        }
        public int FindPreset(PresetViewer viewer)
        {
            for(int i = 0; i < Presets.Count; i++)
            {
                if (viewer.Preset == Presets[i])
                    return i;
            }
            return -1;
        }

        #endregion

        public void ReadTVList()
        {
            var tvList = TVFileController.ReadTVData();
            Viewers.Clear();
            TVViewPanel.Children.Clear();
            for (int i = 0; i < tvList.Count; i++)
            {
                if (FindTVViewPanel(tvList[i], out TVViewer result))
                {
                    //찾는데 성공(이미 존재)
                    result.Initialize(tvList[i]);
                    Viewers.Add(result);
                }
                else
                {
                    //찾는데 실패(존재하지 않음)
                    TVViewer viewer = TVViewer.CreateNew(tvList[i]);
                    TVViewPanel.Children.Add(viewer);
                    Viewers.Add(viewer);
                }
            }
            SortViewersByIndex();
            RemoveUnsedTVViwers();
        }
        public void ReadGroupPresetList()
        {
            var presets = TVFileController.ReadTVGroupData();
            Presets.Clear();
            Presets = presets;
            GroupPresetStackPanel.Children.Clear();

            for (int i = 0; i < presets.Count; i++)
            {
                var viewer = CreateGroupPresetViewer(presets[i]);
                GroupPresetStackPanel.Children.Add(viewer);
                PresetViewers.Add(viewer);
            }

            //SortViewersByIndex();
            RemoveUnsedPresetViwers();
        }
        public void ReadMasterSetting()
        {
            MasterSetting = TVFileController.ReadMasterSettingData();
            if (MasterSettingViewer != null)
                MasterSettingViewer.Refresh();
        }

        public static Setting MasterSetting;
        public SettingViewer MasterSettingViewer;
        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            MasterSettingViewer = new SettingViewer();
            MasterSettingViewer.Show();
            MasterSettingViewer.Topmost = true;
        }

        void SortViewersByIndex()
        {
            for(int i = 0; i < Viewers.Count; i++)
            {
                for(int k = 0; k < i; k++)
                {
                    if(Viewers[i].Data.Index < Viewers[k].Data.Index)
                    {
                        var v = Viewers[i];
                        Viewers[i] = Viewers[k];
                        Viewers[k] = v;
                    }
                }
            }
        }
    }
}
