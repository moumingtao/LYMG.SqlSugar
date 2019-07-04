using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    /// <summary>
    /// 数据库配置，一般一个数据库对应一个实例
    /// </summary>
    public class DbConfig
    {
        public string ConnectionString;
        public DbProvider Provider;
        public TaskScheduler TaskScheduler;

        #region CodeFirst

        #endregion
    }
}
