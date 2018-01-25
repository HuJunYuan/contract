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
    /// 实际回款
    ///</summary>
    [Table("ActualPayment",Schema = "dbo")]
    public partial class ActualPayment : BusinessEntity
    {
    
        /// <summary>
        /// 实际回款标识串
        /// </summary>
        [Key, Required]
        public Guid ActualPaymentGUID { get; set; }
    
        /// <summary>
        /// 合同基本信息标识
        /// </summary>
        
        public Guid? ContractGUID { get; set; }
    
        /// <summary>
        /// 实际回款时间
        /// </summary>
        
        public DateTime? ActualPaymentDate { get; set; }
    
        /// <summary>
        /// 实际回款金额
        /// </summary>
        
        public decimal? ActualPaymentAmount { get; set; }
    
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
    
        ///// <summary>
        ///// 记录项目的一些基本信息
        ///// </summary>
        //[ForeignKey("ContractGUID")]
        //[Newtonsoft.Json.JsonIgnore]
        //public virtual ContractBasicInfo ContractBasicInfo { get; set; }
    }
}
