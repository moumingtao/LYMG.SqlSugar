using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYMG.SqlDB
{
    public class EntityMaintenance
    {
        public EntityInfo GetEntityInfo(Type type)
        {
            string cacheKey = "GetEntityInfo" + type.FullName;
            return this.Context.Utilities.GetReflectionInoCacheInstance().GetOrCreate(cacheKey,
            () =>
            {
                EntityInfo result = new EntityInfo();
                var sugarAttributeInfo = type.GetTypeInfo().GetCustomAttributes(typeof(SugarTable), true).Where(it => it is SugarTable).SingleOrDefault();
                if (sugarAttributeInfo.HasValue())
                {
                    var sugarTable = (SugarTable)sugarAttributeInfo;
                    result.DbTableName = sugarTable.TableName;
                    result.TableDescription = sugarTable.TableDescription;
                }
                if (this.Context.Context.CurrentConnectionConfig.ConfigureExternalServices != null && this.Context.CurrentConnectionConfig.ConfigureExternalServices.EntityNameService != null)
                {
                    if (result.DbTableName == null)
                    {
                        result.DbTableName = type.Name;
                    }
                    this.Context.CurrentConnectionConfig.ConfigureExternalServices.EntityNameService(type, result);
                }
                result.Type = type;
                result.EntityName = result.Type.Name;
                result.Columns = new List<EntityColumnInfo>();
                SetColumns(result);
                return result;
            });
        }
    }
}
