using System.Collections.Generic;
using System.Data.SQLite.EF6.Migrations;
using Masuit.Tools.Security;
using MySql.Data.Entity;
using Quick.Common;
using Quick.Data.Entities.Sys;

namespace Quick.Data.Migrations
{
    using Quick.Data.Infrastructure;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Quick.Data.DefaultDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//�����Զ�Ǩ��
            AutomaticMigrationDataLossAllowed = true;//�Ƿ�����������ݶ�ʧ�������false=�����������쳣��true=�����п������ݻᶪʧ
            if(QuickDbProvider.IsMySql)
                SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());//����Sql������ΪMysql��
            if(QuickDbProvider.IsSqlite)
                SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());//����Sql������ΪSQLite��
        }

        protected override void Seed(Quick.Data.DefaultDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            ViewAndProcedureInitializer.Init(context);
        }
    }
}
