using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LYMG.SqlSugar.Test.Sqlite测试
{
    [TestClass]
    public class UnitTest1
    {
        SqlSugarClient DB;

        [TestInitialize]
        public void init()
        {
            var file = Path.GetFullPath("db.sqlite");
            var config = new ConnectionConfig
            {
                ConnectionString = @"DATA SOURCE=" + file,
                DbType = DbType.Sqlite,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = false,
            };
            DB = new SqlSugarClient(config);
        }

        [TestMethod]
        public void TestMethod1()
        {
            DB.CodeFirst.InitTables<Log1>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            DB.Dispose();
        }
    }
}
