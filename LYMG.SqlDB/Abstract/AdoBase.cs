using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB.Abstract
{
    public abstract class AdoBase
    {
        public virtual string SqlParameterKeyWord => "@";
        public virtual int CommandTimeOut { get; set; }

    }
}
