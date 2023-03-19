using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTVController
{
    [System.Serializable]
    public class Setting
    {
        public float RefreshTimeSec = 5.0f;
        public string MasterSettingPath = "C:\\Users\\micha\\Desktop\\masterSetting.json";
        public string TVDataPath = "C:\\Users\\micha\\Desktop\\tvData.json";
        public string TVGroupPath = "C:\\Users\\micha\\Desktop\\tvGroupData.json";
    }
}
