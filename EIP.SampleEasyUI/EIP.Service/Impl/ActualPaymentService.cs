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
    /// 实际回款服务
    /// </summary>
    public class ActualPaymentService : EntityBaseService, IActualPaymentService
    {
        #region 初始化

        /// <summary>
        /// 实际回款仓储
        /// </summary>
        private ActualPaymentRepository actualPaymentRepository = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uow">工作单元</param>
        /// <param name="factory">仓储创建工厂</param>
        public ActualPaymentService(IUnitOfWork uow, IRepositoryFactory factory)
            : base(uow, factory)
        {
            actualPaymentRepository = this.CreateRepository<ActualPaymentRepository>();
        }

        #endregion

        #region IActualPaymentService method

        /// <summary>
        /// 查询实际回款
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        public List<ActualPayment> QueryActualPayment(QueryModel model, out int totalCount)
        {
            return actualPaymentRepository.QueryActualPayment(model, out totalCount);
        }

        /// <summary>
        /// 处理实际回款
        /// 根据 id 编号判断是否是添加还是更新，然后调用相应的方法进行处理
        /// </summary>
        /// <param name="model">实际回款信息</param>
        /// <returns>处理是否成功</returns>
        public Guid SaveActualPayment(ActualPayment model)
        {
            //检查是否存在重复数据
            var entity = this.Find<ActualPayment>(model.ActualPaymentGUID);

            //更新数据 ， 否则新增数据
            if (entity != null)
            {
                //更新数据
                //entity = Mapper.Map<ActualPayment, ActualPayment>(model, entity);
                this.actualPaymentRepository.Update(entity);
            }
            else
            {
                //录入数据
                model.ActualPaymentGUID = Guid.NewGuid(); //实际回款标识串
                this.actualPaymentRepository.Insert(model);
            }

            return model.ActualPaymentGUID;
        }
        #endregion

        #region private method

        /// <summary>
        /// 处理实际回款
        /// 通过合同Guid ContractGUID获取对应的数据
        /// </summary>
        /// <param name="ContractGUID">合同GUID</param>
        /// <returns>所有属于该合同的实际回款信息</returns>
        public List<ActualPayment> QueryActualPaymentByContractGuid(Guid ContractGUID)
        {
            return actualPaymentRepository.QueryActualPaymentByContractGuid(ContractGUID);
        }
        #endregion
    }
}