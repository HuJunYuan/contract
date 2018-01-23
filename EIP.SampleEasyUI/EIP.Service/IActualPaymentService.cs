/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:34   创建人：Hujunyuan
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
    /// 实际回款服务接口
    /// </summary>
    public interface IActualPaymentService : IEntityService, IService
    {

        /// <summary>
        /// 查询实际回款
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        List<ActualPayment> QueryActualPayment(QueryModel model, out int totalCount);

        /// <summary>
        /// 处理实际回款
        /// 根据 id 编号判断是否是添加还是更新，然后调用相应的方法进行处理
        /// </summary>
        /// <param name="model">实际回款信息</param>
        /// <returns>处理是否成功</returns>
        Guid SaveActualPayment(ActualPayment model);
    }
}
