﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DbTableAttribute : Attribute
    {
    }
}
