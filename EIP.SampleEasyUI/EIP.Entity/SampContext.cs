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

        /// <summary>
        /// 实际回款
        ///</summary>
        public DbSet<ActualPayment> ActualPayment { get; set; }


        /// <summary>
        /// 记录项目的一些基本信息
        ///</summary>
        public DbSet<ContractBasicInfo> ContractBasicInfo { get; set; }


        /// <summary>
        /// 合同回款计划
        ///</summary>
        public DbSet<RepaymentPlan> RepaymentPlan { get; set; }

        #endregion



        void IDisposable.Dispose()
        {
            base.Dispose();
        }
    }
}
