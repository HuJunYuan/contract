/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:32   创建人：Hujunyuan
  描    述：此代码为自动生成代码，请不要手动修改，
            如果有特殊需要请使用partial扩展
-----------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CoreLand.Framework.Authentication;
using CoreLand.Framework.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EIP.Entity
{
    /// <summary>
    /// 记录项目的一些基本信息
    ///</summary>
    [Table("ContractBasicInfo",Schema = "dbo")]
    public partial class ContractBasicInfo : BusinessEntity
    {
    
        /// <summary>
        /// 合同基本信息标识
        /// </summary>
        [Key, Required]
        public Guid ContractGUID { get; set; }
    
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required, MaxLength(50)]
        public string EntryName { get; set; }
    
        /// <summary>
        /// 项目简称
        /// </summary>
        [MaxLength(20)]
        public string Abbreviation { get; set; }
    
        /// <summary>
        /// 合同类型
        /// </summary>
        [MaxLength(20)]
        public string ContractType { get; set; }
    
        /// <summary>
        /// 顾客名字
        /// </summary>
        [MaxLength(20)]
        public string CustomerName { get; set; }
    
        /// <summary>
        /// ResponsibleDepartment
        /// </summary>
        [MaxLength(50)]
        public string ResponsibleDepartment { get; set; }
    
        /// <summary>
        /// 合同签订日期
        /// </summary>
        
        public DateTime? ContractSigningDate { get; set; }
    
        /// <summary>
        /// 合同金额，单位：元
        /// </summary>
        
        public decimal? ContractAmount { get; set; }
    
        /// <summary>
        /// 规模
        /// </summary>
        
        public decimal? Scale { get; set; }
    
        /// <summary>
        /// 服务开始时间
        /// </summary>
        
        public DateTime? StartTime { get; set; }
    
        /// <summary>
        /// 服务结束时间
        /// </summary>
        
        public DateTime? EndTime { get; set; }
    
        /// <summary>
        /// 产值所属年
        /// </summary>
        
        public int? BelongToYear { get; set; }
    
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(100)]
        public string Remarks { get; set; }
    
        /// <summary>
        /// 冗余字段
        /// </summary>
        [MaxLength(100)]
        public string Other { get; set; }
    
        /// <summary>
        /// 实际回款
        /// </summary>
        public virtual IList<ActualPayment> ActualPayments { get; set; }
    
        /// <summary>
        /// 合同回款计划
        /// </summary>
        public virtual IList<RepaymentPlan> RepaymentPlans { get; set; }
    }
}
