using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    /// <summary>
    /// 数据库客户端，一般一个数据库连接对应一个实例，允许多线程非并行访问
    /// </summary>
    public class DbClient : IDisposable
    {
        public readonly DbConfig Config;

        public DbClient(DbConfig config)
        {
            this.Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void Dispose()
        {

        }
    }
}
