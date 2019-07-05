using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public readonly DbProvider Provider;
        public IDbConnection Connection;

        public DbClient(DbProvider provider)
        {
            this.Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public void Dispose()
        {

        }
    }
}
