using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EIP.SystemManage.Entity;
namespace EIP.Entity
{
    public class SampContext : DbContext, IDisposable
    {
        #region ctor
        public SampContext()
            : base(CoreLand.Framework.Helpers.DbHelperSQL.ConnectionString)
        {

            Database.SetInitializer<SampContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
        #endregion

        #region 基本实体模型定义

        public DbSet<AppSettingEntity> AppSetting { get; set; }

        public DbSet<CodeMaster> CodeMaster { get; set; }


        public DbSet<Navigation> Navigation { get; set; }


        /// <summary>
        /// 数据字典
        ///</summary>
        public DbSet<AppCodeMaster> AppCodeMaster { get; set; }


        /// <summary>
        /// 系统配置
        ///</summary>
        public DbSet<AppConfig> AppConfig { get; set; }


        #endregion

        #region 业务实体模型定义


        #endregion



        void IDisposable.Dispose()
        {
            base.Dispose();
        }
    }
}
