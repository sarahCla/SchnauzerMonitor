using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchnauzerMonitor
{
    public class SqlInfo
    {
        public string MasterHost { get; set; }
        public string MasterPort { get; set; }
        public string MasterDbName { get; set; }
        public string SlaveHost { get; set; }
        public string SlavePort { get; set; }
        public string SlaveDbName { get; set; }
        public string SlaveType { get; set; }
        public string SlaveSerialNo { get; set; }
        public string SlaveServerID { get; set; }
        public string BinLog { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }  //1为正常 0 为错误
        public string LastTime { get; set; }  //最后更新包的时间
    }
}
