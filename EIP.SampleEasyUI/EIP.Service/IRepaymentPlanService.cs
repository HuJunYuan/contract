/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:35   创建人：Hujunyuan
  修改时间：                     修改人：          修改内容：
  描    述：
-----------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CoreLand.Framework.Service;
using EIP.Model;
using EIP.Entity;

namespace EIP.Service
{
    /// <summary>
    /// 合同回款计划服务接口
    /// </summary>
    public interface IRepaymentPlanService : IEntityService, IService
    {

        /// <summary>
        /// 查询合同回款计划
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        List<RepaymentPlan> QueryRepaymentPlan(QueryModel model, out int totalCount);

        /// <summary>
        /// 处理合同回款计划
        /// 根据 id 编号判断是否是添加还是更新，然后调用相应的方法进行处理
        /// </summary>
        /// <param name="model">合同回款计划信息</param>
        /// <returns>处理是否成功</returns>
        Guid SaveRepaymentPlan(RepaymentPlan model);

        /// <summary>
        /// 处理实际回款
        /// 通过合同Guid ContractGUID获取对应的数据
        /// </summary>
        /// <param name="ContractGUID">合同GUID</param>
        /// <returns>所有属于该合同的计划回款信息</returns>
        List<RepaymentPlan> QueryRepaymentPlanByContractGuid(Guid ContractGUID);
    }

}
