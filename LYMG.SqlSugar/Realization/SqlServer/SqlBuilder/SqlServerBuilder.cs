﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LYMG.SqlSugar
{
    public class SqlServerBuilder : SqlBuilderProvider
    {
        public override string SqlTranslationLeft { get { return "["; } }
        public override string SqlTranslationRight { get { return "]"; } }
    }
}
