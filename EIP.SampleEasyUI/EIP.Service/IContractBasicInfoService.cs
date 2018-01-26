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
    /// 记录项目的一些基本信息服务接口
    /// </summary>
    public interface IContractBasicInfoService : IEntityService, IService
    {

        /// <summary>
        /// 查询记录项目的一些基本信息
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        List<ContractBasicInfo> QueryContractBasicInfo(QueryModel model, out int totalCount);

        /// <summary>
        /// 处理记录项目的一些基本信息
        /// 根据 id 编号判断是否是添加还是更新，然后调用相应的方法进行处理
        /// </summary>
        /// <param name="model">记录项目的一些基本信息信息</param>
        /// <returns>处理是否成功</returns>
        Guid SaveContractBasicInfo(ContractBasicInfo model);

        // <summary>
        /// 查询记录项目的一些基本信息添补上已回款总金额
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        List<ContractBasicInfoViewModel> QueryContractBasicInfoWithTotalActualPayment();
    }
}
