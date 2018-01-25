/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:33   创建人：Hujunyuan
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
    /// 合同回款计划
    ///</summary>
    [Table("RepaymentPlan",Schema = "dbo")]
    public partial class RepaymentPlan : BusinessEntity
    {
    
        /// <summary>
        /// 合同基本信息标识
        /// </summary>
        [Key, Required]
        public Guid RepaymentPlantGUID { get; set; }
    
        /// <summary>
        /// 合同基本信息标识
        /// </summary>
        
        public Guid? ContractGUID { get; set; }
    
        /// <summary>
        /// 回款计划时间
        /// </summary>
        
        public DateTime? RepaymentPlanDate { get; set; }
    
        /// <summary>
        /// 回款计划金额
        /// </summary>
        
        public decimal? RepaymentPlanAmount { get; set; }
    
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
        /// 记录项目的一些基本信息
        /// </summary>
        [ForeignKey("ContractGUID")]
        [Newtonsoft.Json.JsonIgnore]
        public virtual ContractBasicInfo ContractBasicInfo { get; set; }
    }
}
