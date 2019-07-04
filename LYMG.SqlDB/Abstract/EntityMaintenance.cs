using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    public class EntityMaintenance
    {
        readonly ConcurrentDictionary<Type, DbTableInfo> TableInfoCache = new ConcurrentDictionary<Type, DbTableInfo>();
        readonly ConcurrentDictionary<PropertyInfo, DbColumnInfo> ColumnInfoCache = new ConcurrentDictionary<PropertyInfo, DbColumnInfo>();
        
        /// <summary>
        /// 获取指定类型的表信息，带缓存
        /// </summary>
        /// <param name="type">用于生成表信息的类型</param>
        /// <returns>数据库表信息</returns>
        public virtual DbTableInfo GetTableInfo(Type type) => TableInfoCache.GetOrAdd(type, CreateTableInfo);

        /// <summary>
        /// 创建指定类型的表信息，带列缓存
        /// </summary>
        /// <param name="type">用于生成表信息的类型</param>
        /// <returns>数据库表信息</returns>
        public virtual DbTableInfo CreateTableInfo(Type type)
        {
            var tabInfo = new DbTableInfo();
            tabInfo.Name = type.Name;

            // 获取列信息
            tabInfo.Columns = new List<DbColumnInfo>();
            foreach (var prop in type.GetProperties())
            {
                var colInfo = GetColumnInfo(prop);
                if (!colInfo.NotMapped)
                {
                    if (colInfo.IsTimestamp)
                        tabInfo.TimestampColumn = colInfo;
                    tabInfo.Columns.Add(colInfo);
                }
            }

            // 获取表信息
            foreach (var attr in type.GetCustomAttributes())
            {
                if (attr is TableAttribute tabAttr)
                {
                    tabInfo.Name = tabAttr.Name;
                    tabInfo.Schema = tabAttr.Schema;
                }
                else if (attr is DescriptionAttribute da)
                    tabInfo.Description = da.Description;
                // 如果特性实现了这个接口，可以任意修改表的信息
                else if (attr is ITableAttr ita)
                    ita.ModifyInfo(tabInfo);
            }

            return tabInfo;
        }

        /// <summary>
        /// 获取指定属性的列信息，带缓存
        /// </summary>
        /// <param name="prop">用于生成列信息的属性</param>
        /// <returns>数据库列信息</returns>
        public virtual DbColumnInfo GetColumnInfo(PropertyInfo prop) => ColumnInfoCache.GetOrAdd(prop, CreateColumnInfo);

        /// <summary>
        /// 创建指定属性的列信息，不访问缓存
        /// </summary>
        /// <param name="prop">用于生成列信息的属性</param>
        /// <returns>数据库列信息</returns>
        public virtual DbColumnInfo CreateColumnInfo(PropertyInfo prop)
        {
            DbColumnInfo colInfo = new DbColumnInfo();
            colInfo.Name = prop.Name;

            foreach (var attr in prop.GetCustomAttributes())
            {
                if (attr is KeyAttribute)
                    colInfo.IsKey = true;
                else if (attr is StringLengthAttribute sla)
                {
                    colInfo.MaxLen = sla.MaximumLength;
                    colInfo.MinLen = sla.MinimumLength;
                }
                else if (attr is MaxLengthAttribute mla)
                    colInfo.MaxLen = mla.Length;
                else if (attr is ConcurrencyCheckAttribute)
                    colInfo.IsConcurrencyCheck = true;
                else if (attr is RequiredAttribute ra)
                    colInfo.IsRequired = ra.AllowEmptyStrings;
                else if (attr is TimestampAttribute)
                    colInfo.IsTimestamp = true;
                else if (attr is ColumnAttribute ca)
                {
                    colInfo.Name = ca.Name;
                    colInfo.TypeName = ca.TypeName;
                    colInfo.Order = ca.Order;
                }
                else if (attr is DatabaseGeneratedAttribute dga)
                    colInfo.DatabaseGeneratedOption = dga.DatabaseGeneratedOption;
                else if (attr is NotMappedAttribute nma)
                    colInfo.NotMapped = true;
                else if (attr is DescriptionAttribute da)
                    colInfo.Description = da.Description;
                // 如果特性实现了这个接口，可以任意修改列的信息
                else if (attr is IColumnAttr ica)
                    ica.ModifyInfo(colInfo);
            }

            return colInfo;
        }
    }
}
