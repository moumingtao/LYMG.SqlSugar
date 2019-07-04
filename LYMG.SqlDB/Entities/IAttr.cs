using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    public interface ITableAttr
    {
        void ModifyInfo(DbTableInfo table);
    }

    public interface IColumnAttr
    {
        void ModifyInfo(DbColumnInfo column);
    }
}
