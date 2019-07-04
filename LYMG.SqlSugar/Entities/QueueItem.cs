using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LYMG.SqlSugar
{
    public class QueueItem
    {
        public string Sql { get; set; }
        public SugarParameter[] Parameters { get; set; }
    }
}
