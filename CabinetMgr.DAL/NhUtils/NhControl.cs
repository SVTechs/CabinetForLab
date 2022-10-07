using System;
using System.Configuration;
using System.Data;
using CabinetMgr.Config;
using Domain.Main.Mapping;
using Domain.Main.Types;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Utilities.Encryption;
using Configuration = NHibernate.Cfg.Configuration;

namespace CabinetMgr.DAL.NhUtils
{
    public class NhControl
    {
        //数据库连接池设置
        public static Boolean EnablePooling = false;
        public static int MinPoolSize = 10;
        public static int MaxPoolSize = 100;
        public static int PoolTimeOut = 60;

        private static readonly ISessionFactory[] SessionFactory = new ISessionFactory[10];

        public static ISessionFactory CreateSessionFactory(NhTypes.DbTarget dbTarget = NhTypes.DbTarget.Client)
        {
            int reqDb = (int)dbTarget;
            if (SessionFactory[reqDb] == null)
            {
                switch (reqDb)
                {
                    case 0:
                        //ClientDb
                        SessionFactory[reqDb] = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2005.ConnectionString(GetConnString(reqDb)).IsolationLevel(IsolationLevel.RepeatableRead))
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MapBorrowRecord>())
                            .ExposeConfiguration(BuildSchema)
                            .BuildSessionFactory();
                        break;
                }
            }
            return SessionFactory[reqDb];
        }

        private static string GetConnString(int reqDb)
        {
            string dbConn = "";
            switch (reqDb)
            {
                case 0:
                    dbConn = AesEncryption.DecryptAuto(ConfigurationManager.ConnectionStrings["ClientDb"].ConnectionString, Env.EncSeed); //ConfigurationManager.ConnectionStrings["ClientDb"].ToString();
                    break;
            }
            if (EnablePooling)
            {
                if (!dbConn.EndsWith(";")) dbConn += ";";
                dbConn += string.Format("Pooling=True;Min Pool Size={0};Max Pool Size={1};Connection Timeout={2}", MinPoolSize,
                    MaxPoolSize, PoolTimeOut);
            }
            return dbConn;
        }

        private static void BuildSchema(Configuration config)
        {
            //自动建表,参数2设置为True时将删除表建构并重建
            //new SchemaExport(config).Create(false, false);
        }

        public class SqlWatcher : EmptyInterceptor
        {
            public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
            {
                System.Diagnostics.Debug.WriteLine("Sql: " + sql);
                return base.OnPrepareStatement(sql);
            }
        }
    }
}
