using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using Utilities.Encryption;

namespace Utilities.DbHelper
{
    public class MySqlAccess
    {
        //数据库连接池设置
        public static Boolean EnablePooling = true;
        public static int MinPoolSize = 10;
        public static int MaxPoolSize = 200;
        public static int PoolTimeOut = 60;
        private static string _encSeed = "DbDefault";

        // 哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数。
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        public static MySqlConnection GetConn(string connectionString)
        {
            MySqlConnection conn = new MySqlConnection(GetPoolingString(connectionString));
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 生成支持连接池的连接字符串。
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="originConnString">一个有效的数据库连接字符串</param>
        /// <returns>返回一个带连接池支持的连接字符串</returns>
        private static string GetPoolingString(string originConnString)
        {
            originConnString = AesEncryption.DecryptAuto(originConnString, _encSeed);
            if (!EnablePooling)
            {
                return originConnString;
            }
            originConnString = originConnString.TrimEnd();
            if (!originConnString.EndsWith(";"))
            {
                originConnString += ";";
            }
            string poolingString = string.Format("{0}Pooling=true;Max Pool Size=100;",
                  originConnString, MinPoolSize, MaxPoolSize, PoolTimeOut);
            return poolingString;
        }

        /// <summary>
        ///执行一个不需要返回值的MySqlCommand命令，通过指定专用的连接字符串。
        /// 使用参数数组形式提供参数列表
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">MySqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供MySqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此MySqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(GetPoolingString(connectionString)))
            {
                //通过PrePareCommand方法将参数逐个加入到MySqlCommand的参数集合中
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                //清空MySqlCommand中的参数列表
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        ///执行一条不返回结果的MySqlCommand，通过一个已经存在的数据库连接
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new MyMySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个现有的数据库连接</param>
        /// <param name="cmdType">MySqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供MySqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此MySqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(MySqlConnection connection, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行一条不返回结果的MySqlCommand，通过一个已经存在的数据库事物处理
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个存在的 sql 事物处理</param>
        /// <param name="cmdType">MySqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供MySqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此MySqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行一条返回结果集的MySqlCommand命令，通过专用的连接字符串。
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// MySqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">MySqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供MySqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个包含结果的MySqlDataReader</returns>
        public static MySqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(GetPoolingString(connectionString));
            // 在这里使用try/catch处理是因为如果方法出现异常，则MySqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 执行sql语句，返回数据表
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">sql命令或存储过程名</param>
        /// <param name="spr">参数数组</param>
        /// <returns>返回数据表</returns>
        public static DataTable GetDataTable(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] spr)
        {
            MySqlConnection conn = new MySqlConnection(GetPoolingString(connectionString));
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            if (spr != null)
            { cmd.Parameters.AddRange(spr); }
            cmd.CommandType = cmdType;
            conn.Open();
            MySqlDataReader dr;
            using (dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(dr);
                cmd.Parameters.Clear();
            }
            conn.Close();
            return dt;
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的MySqlCommand命令，通过专用的连接字符串。
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">MySqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供MySqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection connection = new MySqlConnection(GetPoolingString(connectionString)))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static DataSet GetDataSet(string connString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetPoolingString(connString)))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    cmd.Parameters.Clear();
                    if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    {
                        return null;
                    }
                    return ds;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 返回数据集集合，可返回多个表，通过已经存在的数据库连接
        /// </summary>
        public static DataSet GetDataSet(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的MySqlCommand命令，通过已经存在的数据库连接。
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个已经存在的数据库连接</param>
        /// <param name="cmdType">MySqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供MySqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public static object ExecuteScalar(MySqlConnection connection, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 缓存参数数组
        /// </summary>
        /// <param name="cacheKey">参数缓存的键值</param>
        /// <param name="cmdParms">被缓存的参数列表</param>
        public static void CacheParameters(string cacheKey, params MySqlParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        /// <summary>
        /// 获取被缓存的参数
        /// </summary>
        /// <param name="cacheKey">用于查找参数的KEY值</param>
        /// <returns>返回缓存的参数数组</returns>
        public static MySqlParameter[] GetCachedParameters(string cacheKey)
        {
            MySqlParameter[] cachedParms = (MySqlParameter[])parmCache[cacheKey];
            if (cachedParms == null)
                return null;
            //新建一个参数的克隆列表
            MySqlParameter[] clonedParms = new MySqlParameter[cachedParms.Length];
            //通过循环为克隆参数列表赋值
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                //使用clone方法复制参数列表中的参数
                clonedParms[i] = (MySqlParameter)((ICloneable)cachedParms[i]).Clone();
            return clonedParms;
        }

        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">MySqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">MySqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}


