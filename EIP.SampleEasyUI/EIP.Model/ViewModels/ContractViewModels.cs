using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EIP.Entity;
namespace EIP.Model
{
   public class ContractBasicInfoViewModel : ContractBasicInfo
    {
        /// <summary>
        /// 实际回款金额
        /// </summary>
        public decimal? TotalActualPayment { get; set; }
    }
}
