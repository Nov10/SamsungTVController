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
        public string MasterSettingPath = "C:\\masterSetting.json";
        public string TVDataPath = "C:\\tvData.json";
        public string TVGroupPath = "C:\\tvGroupData.json";
    }
}
