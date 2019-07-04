using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    /// <summary>
    /// 数据库提供程序，配置数据库访问方式，允许并行访问
    /// </summary>
    public abstract class DbProvider
    {
        public virtual string ConnectionString { get; set; }
        public TaskScheduler TaskScheduler;
        public EntityMaintenance EntityMaintenance;
    }
}
