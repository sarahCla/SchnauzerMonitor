using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace SchnauzerMonitor
{
    public partial class Form1 : Form
    {
        private static IList<SqlInfo> allListData  = new List<SqlInfo>();
        private System.Threading.Timer t;   //申明了一个全局的，不然要被gc回收
        private Random d = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 处理
        /// </summary>
        private void dealDataHander(byte[] data)
        {
            SqlInfo temp = DealReceiveData(data);    // 得到客户端发来的数据并解析数据
            doDataGridInsertData(temp);

            DataGridInfo.BeginInvoke(new MethodInvoker(delegate()
            {
                BindDataSource();
            }), data);
        }

        /// <summary>
        /// 满足条件的设置背景颜色(Red)
        /// </summary>
        
        private void SetDataGridRowBackGround()
        {
            lock (this)
            {
                foreach (DataGridViewRow row in DataGridInfo.Rows)
                {
                    if (!(row.Cells[11].Value ?? "").ToString().Equals(Constant.Normal))
                        row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// DataGrid中插入接收到的数据
        /// </summary>
        private void doDataGridInsertData(SqlInfo temp)
        {
            lock (this)
            {
                bool flag = true;
                foreach (SqlInfo data in allListData)
                {
                    if (IsEqualsSqlInfo(temp, data))
                    {
                        data.BinLog = temp.BinLog;
                        data.Position = temp.Position;
                        data.Status = temp.Status;
                        data.LastTime = temp.LastTime;
                        flag = false;
                        break;
                    }
                }
                if (flag) allListData.Add(temp);
            }
        }
        
        /// <summary>
        /// sqlinfo信息是否在List中存在
        /// </summary>
        private bool IsEqualsSqlInfo(SqlInfo receiveSqlInfo, SqlInfo dataGridSqlInfo)
        {
            return receiveSqlInfo.MasterDbName == dataGridSqlInfo.MasterDbName && receiveSqlInfo.MasterHost == dataGridSqlInfo.MasterHost && receiveSqlInfo.SlaveDbName == dataGridSqlInfo.SlaveDbName && receiveSqlInfo.SlaveHost == dataGridSqlInfo.SlaveHost;
        }

        /// <summary>
        /// 从字节流中提取数据
        /// </summary>
        private SqlInfo DealReceiveData(byte[] data)
        {
            string b = System.Text.Encoding.UTF8.GetString(data).TrimEnd('\0');

            /*
            string error = string.Format("<Result><PacketFlag flag=\"0\"/><Config Master=\"192.168.3.53\" MasterPort=\"3306\" MasterDBName=\"{0}\" Slave=\"192.168.12.162\" SlavePort=\"3306\" SlaveDBName=\"roshallslave\" type=\"mysql\"/><Error ErrorContent=\"update command faild\"/></Result>", "roshall" + new Random().Next(10));
            string s = string.Format("<Result><PacketFlag flag=\"1\"/><MasterDBInfo Host=\"192.168.3.53\" port=\"3306\" dbname=\"{0}\"/><SlaveDBInfo Host=\"192.168.12.162\" port=\"3306\" dbname=\"roshallslave\" type=\"sqlserver\" SerailNo=\"0AEe\" serverid=\"21\" Binlog=\"SarahCla.0002\" Position=\"2333\"/></Result>", "roshall" + new Random().Next(10));
            SqlInfo sqlinfo = FileHelp.LoadXmlToClass(d.Next(100) < 50 ? s : error); 
             */
            SqlInfo sqlinfo = FileHelp.LoadXmlToClass(b);
            //IsShowMainFrom(sqlinfo.Status != Constant.Normal);
            return sqlinfo;
        }

        /// <summary>
        /// 当有错误的日志来了，如果窗口是最小化，则自动弹出
        /// </summary>
        private void IsShowMainFrom(bool isShow)
        {
            if (!isShow) return;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.TopLevel = true;
                this.Activate();
            }
        }

        /// <summary>
        /// 删除行记录
        /// </summary>
        private void Del_Click(object sender, EventArgs e)
        {
            if (DataGridInfo.DataSource != null)
            {
                int index = DataGridInfo.CurrentRow.Index;
                allListData.RemoveAt(index);
                BindDataSource();
            }
        }

        private void protSet(object sender, EventArgs e)
        {
            Form form = new PortForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 程序开始
        /// </summary>
        private void DoStart(object sender, EventArgs e)
        {
            string result = FileHelp.DoReadFile();
            bool flag = new FileHelp(result).RegexRuleIpPort();
            if (!flag) return;
           
            ListenHelper listen = new ListenHelper(new IPEndPoint(GetLocalHost(), Convert.ToInt32(result)));
            listen.dealDataHander += dealDataHander;
            listen.Open();
            Start.Enabled = false;
            IpPort.Enabled = false;
            this.Text = "SchnauzerMonitor   正在监控端口：" + result.ToString();
            DoCheckInterrupt();
            
        }

        /// <summary>
        /// 获取本机IP
        /// </summary>
        /// <returns></returns>
        private IPAddress GetLocalHost()
        {
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = null;

            foreach (IPAddress ip in ipe.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip;
            }
            return ipAddress;
        }

        private void DoExit(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// 查看日志
        /// </summary>
        private void DoReadErrLog(object sender, EventArgs e)
        {
            FileHelp.CreateFile();
            System.Diagnostics.Process.Start("explorer.exe", Constant.Folder);
        }

        /// <summary>
        /// 中断检查（如果有错误或者中断，则要显示主界面）
        /// </summary>
        private void DoCheckInterrupt()
        {
            TimerCallback timeCB = new TimerCallback(CheckInterrupt);
            t = new System.Threading.Timer(timeCB, null, Constant.InterruptCheckTiem, Constant.InterruptCheckTiem); //1分钟后启动， 1分钟检查一次
        }

        private void CheckInterrupt(object state)
        {
            TimeSpan daySpan = new TimeSpan(System.DateTime.Now.Ticks);
            double timeSpanValue = 0;
            bool flag = false;
            bool isNormal = true;

            foreach (SqlInfo rowData in allListData)
            {
                if (isNormal && rowData.Status != Constant.Normal) isNormal = false;
                TimeSpan lastTimeSpan = stringtoTimeSpan(rowData.LastTime);
                timeSpanValue = TiemCompare(lastTimeSpan, daySpan);
                if (timeSpanValue > Constant.timeSpanValue)
                {
                    flag = true;
                    rowData.Status = Constant.Interrupt;
                }
            }

            if (flag)
            {
                //BindDataSource();
                DataGridInfo.BeginInvoke(new MethodInvoker(delegate()
                {
                    BindDataSource();
                }), null);
            }

            IsShowMainFrom(!isNormal || flag);
        }

        /// <summary>
        /// 绑定数据到DataGridView
        /// </summary>
        private void BindDataSource()
        {
            DataGridInfo.DataSource = null;
            DataGridInfo.DataSource = allListData;
            SetDataGridRowBackGround();
        }

        /// <summary>
        /// 时间比较
        /// </summary>
        private double TiemCompare(TimeSpan lastTimeSpan, TimeSpan daySpan)
        {
            return daySpan.Subtract(lastTimeSpan).Duration().TotalSeconds;
        }


        /// <summary>
        /// 把最后时间字符串转为时间间隔
        /// </summary>
        private TimeSpan stringtoTimeSpan(string lastTime)
        {
            DateTime datetime = DateTime.Parse(lastTime);
            return new TimeSpan(datetime.Ticks);
        }

        private void DoResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1 = new System.Windows.Forms.NotifyIcon();
            //notifyIcon1.Icon = new Icon(@"schnauzerMonitor.png");
            notifyIcon1.Text = "SchnauzerNonitor";
            notifyIcon1.MouseClick += new MouseEventHandler(notifyIcon1_MouseClick);
            
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            DataGridInfo.RowTemplate.ContextMenuStrip = rightMenuStrip;     //DataGrid行添加右键功能
        }

        /// <summary>
        /// 单击任务栏上的图片，显示主窗体
        /// </summary>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.TopLevel = true;
                    this.Activate();
                }
            }
        }

        /// <summary>
        /// 点击图标显示窗体
        /// </summary>
        private void ShowFrom_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.TopLevel = true;
                    this.Activate();
                }
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        private void BackFrom_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Dispose();
                this.Close();
            }
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        private void HideFrom_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }
     }
}
