﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;

namespace LYMG.SqlSugar
{
    internal class CallContext
    {
        public static ThreadLocal<List<SqlSugarProvider>> ContextList = new ThreadLocal<List<SqlSugarProvider>>();
    }
}
