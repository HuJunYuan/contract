/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:35   创建人：Hujunyuan
  修改时间：                     修改人：          修改内容：
  描    述：
-----------------------------------------------------------------------------*/
using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using Newtonsoft.Json;
using AutoMapper;

using CoreLand.Framework;
using CoreLand.Framework.Data;
using CoreLand.Framework.Service;
using CoreLand.Framework.Code;
using CoreLand.Framework.Authentication;
using CoreLand.Framework.Helpers;
using EIP.Model;
using EIP.Repository;
using EIP.Entity;

namespace EIP.Service
{
    /// <summary>
    /// 记录项目的一些基本信息服务
    /// </summary>
    public class ContractBasicInfoService : EntityBaseService, IContractBasicInfoService
    {
        #region 初始化

        /// <summary>
        /// 记录项目的一些基本信息仓储
        /// </summary>
        private ContractBasicInfoRepository contractBasicInfoRepository = null;


        /// <summary>
        /// 记录实际回款信息仓储
        /// </summary>
        private ActualPaymentRepository actualPaymentRepository = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uow">工作单元</param>
        /// <param name="factory">仓储创建工厂</param>
        public ContractBasicInfoService(IUnitOfWork uow, IRepositoryFactory factory)
            : base(uow, factory)
        {
            contractBasicInfoRepository = this.CreateRepository<ContractBasicInfoRepository>();
            actualPaymentRepository = this.CreateRepository<ActualPaymentRepository>();
        }

        #endregion

        #region IContractBasicInfoService method

        /// <summary>
        /// 查询记录项目的一些基本信息
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        public List<ContractBasicInfo> QueryContractBasicInfo(QueryModel model, out int totalCount)
        {
            return contractBasicInfoRepository.QueryContractBasicInfo(model, out totalCount);
        }

        /// <summary>
        /// 查询记录项目的一些基本信息添补上已回款总金额
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        public List<ContractBasicInfoViewModel> QueryContractBasicInfoWithTotalActualPayment()
        {
            var contractList = contractBasicInfoRepository.QueryContractBasicInfo();
            List<ContractBasicInfoViewModel> conViewModels = new List<ContractBasicInfoViewModel>();

            foreach (var item in contractList)
            {
                ContractBasicInfoViewModel temp = new ContractBasicInfoViewModel();
                temp = Mapper.Map<ContractBasicInfo, ContractBasicInfoViewModel>(item, temp);
                temp.TotalActualPayment = actualPaymentRepository.queryTotolMoney(item.ContractGUID);
                conViewModels.Add(temp);

            }
            return conViewModels;
        }

        /// <summary>
        /// 处理记录项目的一些基本信息
        /// 根据 id 编号判断是否是添加还是更新，然后调用相应的方法进行处理
        /// </summary>
        /// <param name="model">记录项目的一些基本信息信息</param>
        /// <returns>处理是否成功</returns>
        public Guid SaveContractBasicInfo(ContractBasicInfo model)
        {
            //检查是否存在重复数据
            var entity = this.Find<ContractBasicInfo>(model.ContractGUID);

            //更新数据 ， 否则新增数据
            if (entity != null)
            {
                entity.ActualPayments.ForEach(s => { s.ContractBasicInfo = entity; });
                entity.RepaymentPlans.ForEach(r => { r.ContractBasicInfo = entity; });
                //更新数据
                entity = Mapper.Map<ContractBasicInfo, ContractBasicInfo>(model, entity);
                this.contractBasicInfoRepository.Update(entity);
            }
            else
            {
                //录入数据
                model.ContractGUID = Guid.NewGuid(); //合同基本信息标识
                this.contractBasicInfoRepository.Insert(model);
            }

            return model.ContractGUID;
        }
        #endregion

        #region private method

        #endregion
    }
}