using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    public class DbColumnInfo
    {
        public string Name;
        public bool IsKey;
        public int MaxLen;
        public int MinLen;
        public bool IsConcurrencyCheck;
        public bool IsRequired;
        public bool IsTimestamp;
        public string TypeName;
        public int Order;
        public DatabaseGeneratedOption DatabaseGeneratedOption;
        public bool NotMapped;
        internal string Description;
    }
}
