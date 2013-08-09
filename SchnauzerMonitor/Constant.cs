using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SchnauzerMonitor
{
    static class Constant
    {
        /// <summary>
        /// 文件夹地址
        /// </summary>
        public static string Folder = @"C:\SchnauzerMonitor\";
        /// <summary>
        /// 文件名
        /// </summary>
        public static string FileName = "ipprot.config";
        /// <summary>
        /// 文件地址
        /// </summary>
        public static string FolderFileName = @"C:\SchnauzerMonitor\ipprot.config";
        /// <summary>
        /// 时间的间隔超过了180S，则视为中断处理
        /// </summary>
        public static double timeSpanValue = 20;

        /// <summary>
        /// 正常
        /// </summary>
        public static string Normal = "正常";
        /// <summary>
        /// 错误
        /// </summary>
        public static string Error = "错误";
        /// <summary>
        /// 中断
        /// </summary>
        public static string Interrupt = "中断";
        /// <summary>
        /// 每隔60秒，检查一次
        /// </summary>
        public static int InterruptCheckTiem = 5000;

    }
}
