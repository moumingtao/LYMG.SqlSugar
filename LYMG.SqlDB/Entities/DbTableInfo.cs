using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    public class DbTableInfo
    {
        public string Name;
        public string Description;
        public List<DbColumnInfo> Columns;
        public DbColumnInfo TimestampColumn;
        public string Schema;
    }
}
