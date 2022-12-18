using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.FileHelper;

namespace CabinetMgr.Config
{
    public class AppConfig
    {
        /// <summary>
        /// 程序名称
        /// </summary>
        public static string AppName
        {
            get => _appName;
            set
            {
                _appName = value;
                IniHelper.Write("AppConfig", "AppName", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 程序单位
        /// </summary>
        public static string AppUnit
        {
            get => _appUnit;
            set
            {
                _appUnit = value;
                IniHelper.Write("AppConfig", "AppUnit", value.ToString(), Env.ConfigPath);
            }
        }


        /// <summary>
        /// 用于屏蔽协助功能
        /// </summary>
        public static int DisableWatcher
        {
            get => _disableWatcher;
            set
            {
                _disableWatcher = value;
                IniHelper.Write("AppConfig", "DisableWatcher", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 调试模式开关
        /// </summary>
        public static int DebugMode
        {
            get => _debugMode;
            set
            {
                _debugMode = value;
                IniHelper.Write("AppConfig", "DebugMode", value.ToString(), Env.ConfigPath);
            }
        }

        public static int RecvLog
        {
            get => _recvLog;
            set
            {
                _recvLog = value;
                IniHelper.Write("AppConfig", "RecvLog", value.ToString(), Env.ConfigPath);
            }
        }

        public static int InitDB
        {
            get => _initDB;
            set
            {
                _initDB = value;
                IniHelper.Write("AppConfig", "InitDB", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 实验室名
        /// </summary>
        public static string LabName
        {
            get => _labName;
            set
            {
                _labName = value;
                IniHelper.Write("AppConfig", "LabName", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 位置编号
        /// </summary>
        public static int Location
        {
            get => _location;
            set
            {
                _location = value;
                IniHelper.Write("AppConfig", "Location", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 指纹仪COM端口号
        /// </summary>
        public static int FpPort
        {
            get => _fpPort;
            set
            {
                _fpPort = value;
                IniHelper.Write("AppConfig", "FpPort", value.ToString(), Env.ConfigPath);
            }
        }

        public static string ServerIP
        {
            get => _serverIP;
            set
            {
                _serverIP = value;
                IniHelper.Write("AppConfig", "ServerIP", value.ToString(), Env.ConfigPath);
            }
        }

        public static int ServerPort
        {
            get => _serverPort;
            set
            {
                _serverPort = value;
                IniHelper.Write("AppConfig", "ServerPort", value.ToString(), Env.ConfigPath);
            }
        }


        public static string CanIP
        {
            get => _canIP;
            set
            {
                _canIP = value;
                IniHelper.Write("AppConfig", "CanIP", value.ToString(), Env.ConfigPath);
            }
        }

        public static int CameraPort
        {
            get => _cameraPort;
            set
            {
                _cameraPort = value;
                IniHelper.Write("AppConfig", "CameraPort", value.ToString(), Env.ConfigPath);
            }
        }


        private static string _appName = "智能储物柜";
        private static string _appUnit = "";

        private static int _disableWatcher;
        private static int _debugMode = 1;
        private static int _recvLog = 1;
        private static int _initDB = 0;

        private static string _labName = "";
        private static int _location = 0;
        private static int _fpPort = 1;
        private static string _serverIP = "6.6.6.6";
        private static int _serverPort = 8502;
        private static string _canIP = "6.6.6.100";
        private static int _cameraPort = 0;


    }
}
