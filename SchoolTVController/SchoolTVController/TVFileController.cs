using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using SchoolTVController;

namespace TVControl
{
    public class TVFileController
    {
        public static void WriteTVData(List<TVData> data)
        {
            TVDataWrapper wrapper = new TVDataWrapper();
            wrapper.Datas = data.ToArray();

            var j = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            File.WriteAllText(MainWindow.MasterSetting.TVDataPath, j.ToString());
        }
        public static void WriteTVData(List<TVViewer> list)
        {
            List<TVData> data = new List<TVData>();
            for(int i = 0; i < list.Count; i++)
            {
                data.Add(list[i].Data);
            }
            TVDataWrapper wrapper = new TVDataWrapper();
            wrapper.Datas = data.ToArray();

            var j = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            File.WriteAllText(MainWindow.MasterSetting.TVDataPath, j.ToString());
        }
        public static List<TVData> ReadTVData()
        {
            if (File.Exists(MainWindow.MasterSetting.TVDataPath) == false)
            {
                List<TVData> list = new List<TVData>();
                list.Add(new TVData());
                TVControl.TVFileController.WriteTVData(list);
            }
            var jsonText = File.ReadAllText(MainWindow.MasterSetting.TVDataPath);
            var data = JsonConvert.DeserializeObject<TVDataWrapper>(jsonText);
            return new List<TVData>(data.Datas);
        }
        [System.Serializable]
        class TVDataWrapper
        {
            public TVData[] Datas;
        }

        public static void WriteTVGroupData(List<SchoolTVController.GroupPreset> data)
        {
            MainWindow.Instance.ValidatePresets(data);
            GroupPresetWrapper wrapper = new GroupPresetWrapper();
            wrapper.Datas = data.ToArray();

            var j = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            File.WriteAllText(MainWindow.MasterSetting.TVGroupPath, j.ToString());
        }
        public static List<SchoolTVController.GroupPreset> ReadTVGroupData()
        {
            if (File.Exists(MainWindow.MasterSetting.TVGroupPath) == false)
            {
                List<GroupPreset> presets = new List<GroupPreset>();
                presets.Add(new GroupPreset());
                TVControl.TVFileController.WriteTVGroupData(presets);
            }

            var jsonText = File.ReadAllText(MainWindow.MasterSetting.TVGroupPath);
            var data = JsonConvert.DeserializeObject<GroupPresetWrapper>(jsonText);
            return new List<SchoolTVController.GroupPreset>(data.Datas);
        }
        [System.Serializable]
        class GroupPresetWrapper
        {
            public SchoolTVController.GroupPreset[] Datas;
        }

        public static void WriteMasterSettingData(Setting setting)
        {
            var j = JsonConvert.SerializeObject(setting, Formatting.Indented);

            File.WriteAllText(MainWindow.MasterSetting.MasterSettingPath, j.ToString());
        }
        public static Setting ReadMasterSettingData()
        {
            if (File.Exists(MainWindow.MasterSetting.MasterSettingPath) == false)
            {
                Setting setting = new Setting();
                TVControl.TVFileController.WriteMasterSettingData(setting);
            }

            var jsonText = File.ReadAllText(MainWindow.MasterSetting.MasterSettingPath);
            var data = JsonConvert.DeserializeObject<Setting>(jsonText);
            return data;
        }
    }
}
