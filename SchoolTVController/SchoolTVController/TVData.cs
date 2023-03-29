using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVControl
{
    [System.Serializable]
    public class TVData
    {
        public string Name;
        public string DeviceID;
        public string IP;
        public int Index;
        public string Description;
        public string InstanceID;

        public TVData()
        {
            InstanceID = System.Guid.NewGuid().ToString() + System.Guid.NewGuid().ToString() + DateTime.Now.ToString();
        }
    }
}
