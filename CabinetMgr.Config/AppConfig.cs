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
        /// 程序名称，用于软件更新
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
        /// 程序单位，用于软件更新
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

        /// <summary>
        /// 本地演示模式开关
        /// </summary>
        public static int LocalMode
        {
            get => _localMode;
            set
            {
                _localMode = value;
                IniHelper.Write("AppConfig", "LocalMode", value.ToString(), Env.ConfigPath);
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

        /// <summary>
        /// 工具柜COM号
        /// </summary>
        public static string CabinetPort
        {
            get => _cabinetPort;
            set
            {
                _cabinetPort = value;
                IniHelper.Write("AppConfig", "CabinetPort", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 下班时间(下班后未归还设备将显示异常)
        /// </summary>
        public static string OffDutyTime
        {
            get => _offDutyTime;
            set
            {
                _offDutyTime = value;
                IniHelper.Write("AppConfig", "OffDutyTime", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 工具柜名(用于数据同步等，请保证各个工具柜此项不同)
        /// </summary>
        public static string CabinetName
        {
            get => _cabinetName;
            set
            {
                _cabinetName = value;
                IniHelper.Write("AppConfig", "CabinetName", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 工具柜编号(用于数据同步等，请保证各个工具柜此项不同)
        /// </summary>
        public static string CabinetNo
        {
            get => _cabinetNo;
            set
            {
                _cabinetNo = value;
                IniHelper.Write("AppConfig", "CabinetNo", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 同步功能WebService地址
        /// </summary>
        public static string SyncServiceUrl
        {
            get => _syncServiceUrl;
            set
            {
                _syncServiceUrl = value;
                IniHelper.Write("AppConfig", "SyncServiceUrl", value.ToString(), Env.ConfigPath);
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

        /// <summary>
        /// 电脑无操作，门未关，有用户登录的报警时间(超过这时间就报警)，单位s
        /// </summary>
        public static int AlarmTime
        {
            get => _alarmTime;
            set
            {
                _alarmTime = value;
                IniHelper.Write("AppConfig", "AlarmTime", value.ToString(), Env.ConfigPath);
            }
        }

        /// <summary>
        /// 电脑无操作，门未关，有用户登录的报警记录时间(超过这时间就记录在数据库中)，单位s
        /// </summary>
        //public static int AlarmRecordTime
        //{
        //    get => _alarmRecordTime;
        //    set
        //    {
        //        _alarmRecordTime = value;
        //        IniHelper.Write("AppConfig", "AlarmRecordTime", value.ToString(), Env.ConfigPath);
        //    }
        //}

        /// <summary>
        /// 用户自动退出时间，关门且无操作，超过这个时间，用户自动退出，单位s
        /// </summary>
        public static int UserQuitTime
        {
            get => _userQuitTime;
            set
            {
                _userQuitTime = value;
                IniHelper.Write("AppConfig", "UserQuitTime", value.ToString(), Env.ConfigPath);
            }
        }

        public static string SensorMapping
        {
            get => _sensorMapping;
            set
            {
                _sensorMapping = value;
                IniHelper.Write("AppConfig", "SensorMapping", value.ToString(), Env.ConfigPath);
            }
        }

        public static string ModuleDoorCount
        {
            get => _moduleDoorCount;
            set
            {
                _moduleDoorCount = value;
                IniHelper.Write("AppConfig", "ModuleDoorCount", value.ToString(), Env.ConfigPath);
            }
        }

        public static int AlarmEnable
        {
            get => _alarmEnable;
            set
            {
                _alarmEnable = value;
                IniHelper.Write("AppConfig", "AlarmEnable", value.ToString(), Env.ConfigPath);
            }
        }

        public static int LowAmountEnable
        {
            get => _lowAmountEnable;
            set
            {
                _lowAmountEnable = value;
                IniHelper.Write("AppConfig", "LowAmountEnable", value.ToString(), Env.ConfigPath);
            }
        }

        public static int StockAmountChangeable
        {
            get => _stockAmountChangeable;
            set
            {
                _stockAmountChangeable = value;
                IniHelper.Write("AppConfig", "StockAmountChangeable", value.ToString(), Env.ConfigPath);
            }
        }

        public static int DefaultStockAmount
        {
            get => _defaultStockAmount;
            set
            {
                _defaultStockAmount = value;
                IniHelper.Write("AppConfig", "DefaultStockAmount", value.ToString(), Env.ConfigPath);
            }
        }

        public static int UsingMode
        {
            get => _usingMode;
            set
            {
                _usingMode = value;
                IniHelper.Write("AppConfig", "UsingMode", value.ToString(), Env.ConfigPath);
            }
        }

        public static string JxUrl
        {
            get => _jxUrl;
            set
            {
                _jxUrl = value;
                IniHelper.Write("AppConfig", "JxUrl", value.ToString(), Env.ConfigPath);
            }
        }

        public static string ZbUrl
        {
            get => _zbUrl;
            set
            {
                _zbUrl = value;
                IniHelper.Write("AppConfig", "ZbUrl", value.ToString(), Env.ConfigPath);
            }
        }

        public static string CabinetId
        {
            get => _cabinetId;
            set
            {
                _cabinetId = value;
                IniHelper.Write("AppConfig", "CabinetId", value.ToString(), Env.ConfigPath);
            }
        }

        public static string LocoAddress
        {
            get => _locoAddress;
            set
            {
                _locoAddress = value;
                IniHelper.Write("AppConfig", "LocoAddress", value.ToString(), Env.ConfigPath);
            }
        }

        private static string _appName = "智能微库";
        private static string _appUnit = "新联铁";

        private static int _disableWatcher;

        private static int _debugMode;
        private static int _localMode;
        private static int _recvLog = 1;
        private static string _cabinetPort = "1";
        private static string _offDutyTime = "16:00";

        private static string _cabinetName = "";
        private static string _cabinetNo = "";
        private static string _syncServiceUrl = "";//"http://10.128.177.61:8080/CabinetService/SyncService.asmx";
        private static int _fpPort = 1;

        private static int _alarmTime = 60;
        //private static int _alarmRecordTime = 120;
        private static int _userQuitTime = 60;
        private static string _sensorMapping = "";
        private static string _moduleDoorCount = "";

        private static int _alarmEnable = 1;
        private static int _lowAmountEnable = 1;
        private static int _stockAmountChangeable = 0;
        private static int _defaultStockAmount = 1;
        private static int _usingMode = 0;
        private static string _jxUrl = "";
        private static string _zbUrl = "";
        private static string _cabinetId = "";
        private static string _locoAddress = "";


    }
}
