using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace SchnauzerMonitor
{
    class FileHelp
    {
        private string Port;

        public FileHelp() { }

        public FileHelp(string port)
        {
            Port = port ?? "";
        }

        /// <summary>
        /// 保存文件
        /// </summary
        public bool DoSaveFile()
        {
            bool flag = true;
            flag = RegexRuleIpPort();
            if (flag) SaveFile();
            return flag;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        public static string DoReadFile()
        {
            string path = Constant.FolderFileName;
            string result = string.Empty;
            if (!File.Exists(path)) return result;
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String line;
                    if ((line = sr.ReadLine()) != null)
                       result = line;
                    sr.Dispose();
                    sr.Close();
                }
            }
            catch
            {
            }
            return result;
        }

        private void SaveFile()
        {
            CreateFile();
            using(FileStream fs = File.OpenWrite(Constant.FolderFileName))
            {
                byte[] info = System.Text.Encoding.GetEncoding("GB2312").GetBytes(string.Format("{0}",Port));
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
        }


        /// <summary>
        /// 验证ip和端口格式是否正确
        /// </summary>
        public bool RegexRuleIpPort()
        {
            bool flag = true;
            if (!Regex.IsMatch(Port, @"^\d{1,}$"))
            {
                MessageBox.Show("端口的格式不对！");
                flag = false;
            }
            //else if (!Regex.IsMatch(IP, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
            //{
            //    MessageBox.Show("ip的格式不对！");
            //    flag = false;
            //}

            return flag;
        }

        /// <summary>
        /// 判断文件是否存在，不存在则创建
        /// </summary>
        public static void CreateFile()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Constant.Folder);
            if (!dirInfo.Exists)
                dirInfo.Create();

            FileInfo fileInfo = new FileInfo(Constant.FolderFileName);
            if (!fileInfo.Exists)
                fileInfo.Create().Close();
        }

        /// <summary>
        /// 加载并解析xml数据，返回一个sqlinfo类
        /// </summary>
        public static SqlInfo LoadXmlToClass(string data)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(data);

            //1为正常包 0为错误包
            string flag = xmlDoc.ChildNodes[0].ChildNodes[0].Attributes[0].Value;

            if (flag == "0")
            {
                WriteErrorLog(data);
            }

            XmlNodeList nodeList = xmlDoc.ChildNodes;
            return (flag == "1") ? BuildRightClass(nodeList) : BuildErrorClass(nodeList);
        }

        /// <summary>
        /// 错误的信息要写日志
        /// </summary>
        /// <param name="errorLog"></param>
        private static void WriteErrorLog(string errorLog)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Constant.Folder);
            if (!dirInfo.Exists)
                dirInfo.Create();
            CreateLogFile(errorLog);
        }

        /// <summary>
        /// 创建文件并写如日志
        /// </summary>
        private static void CreateLogFile(string errorLog)
        {
            string fileName = System.DateTime.Now.ToString("yyyy-MM-dd");
            string path = Constant.Folder + fileName+ ".txt";
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
                fileInfo.Create().Close();

            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sw.WriteLine(errorLog);
            sw.Close(); 
        }

        /// <summary>
        /// 构建正确的类
        /// </summary>
        private static SqlInfo BuildRightClass(XmlNodeList nodeList)
        {
            SqlInfo sqlInfo = new SqlInfo();
            XmlNode MasterDBInfo = nodeList[0].ChildNodes[1];
            XmlNode SlaveDBInfo = nodeList[0].ChildNodes[2];

            sqlInfo.MasterHost = MasterDBInfo.Attributes[0].Value;
            sqlInfo.MasterPort = MasterDBInfo.Attributes[1].Value;
            sqlInfo.MasterDbName = MasterDBInfo.Attributes[2].Value;

            sqlInfo.SlaveHost = SlaveDBInfo.Attributes[0].Value;
            sqlInfo.SlavePort = SlaveDBInfo.Attributes[1].Value;
            sqlInfo.SlaveDbName = SlaveDBInfo.Attributes[2].Value;
            sqlInfo.SlaveType = SlaveDBInfo.Attributes[3].Value;
            sqlInfo.SlaveSerialNo = SlaveDBInfo.Attributes[4].Value;
            sqlInfo.SlaveServerID = SlaveDBInfo.Attributes[5].Value;
            sqlInfo.BinLog = SlaveDBInfo.Attributes[6].Value;
            sqlInfo.Position = SlaveDBInfo.Attributes[7].Value;
            sqlInfo.LastTime = System.DateTime.Now.ToString("HH:mm:ss MM-dd");
            sqlInfo.Status = Constant.Normal;
            return sqlInfo;
        }

        /// <summary>
        /// 构建错误的类
        /// </summary>
        private static SqlInfo BuildErrorClass(XmlNodeList nodeList)
        {
            SqlInfo sqlInfo = new SqlInfo();
            XmlNode Config = nodeList[0].ChildNodes[1];
            XmlNode Error = nodeList[0].ChildNodes[2];

            sqlInfo.MasterHost = Config.Attributes[0].Value;
            sqlInfo.MasterPort = Config.Attributes[1].Value;
            sqlInfo.MasterDbName = Config.Attributes[2].Value;
            sqlInfo.SlaveHost = Config.Attributes[3].Value;
            sqlInfo.SlavePort = Config.Attributes[4].Value;
            sqlInfo.SlaveDbName = Config.Attributes[5].Value;
            sqlInfo.SlaveType = Config.Attributes[6].Value;

            sqlInfo.LastTime = System.DateTime.Now.ToString("HH:mm:ss MM-dd");
            sqlInfo.Status = Constant.Error;
            return sqlInfo;
        }
    }
}
