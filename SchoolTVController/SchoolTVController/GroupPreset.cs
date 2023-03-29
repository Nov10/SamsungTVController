using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTVController
{
    [System.Serializable]
    public class GroupPreset
    {
        public string Name = string.Empty;
        //public List<string> DeviceIDs = new List<string>();
        //public List<string> Names = new List<string>();
        public List<string> InstanceIDs = new List<string>();
        public int Index = 0;
    }
}
