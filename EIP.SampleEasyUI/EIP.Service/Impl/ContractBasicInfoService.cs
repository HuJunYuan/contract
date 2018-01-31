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
        /// 查询记录项目的一些基本信息添补上已回款总金额
        /// </summary>
        /// <param name="pageNumber">翻页查询页码</param>
        /// <param name="pageSize">分页大小
        public List<ContractBasicInfoViewModel> QueryContractBasicInfoWithTotalActualPayment(int pageNumber, int pageSize)
        {
            //通过页码和分页大小查出当前页的合同信息列表
            var contractList = contractBasicInfoRepository.QueryContractBasicInfo(pageNumber,pageSize);

            //创建一个合同视同列表对象
            List<ContractBasicInfoViewModel> conViewModels = new List<ContractBasicInfoViewModel>();

            //将每个合同的实际回款总额计算出来
            foreach (var item in contractList)
            {
                ContractBasicInfoViewModel temp = new ContractBasicInfoViewModel();
                temp = Mapper.Map<ContractBasicInfo, ContractBasicInfoViewModel>(item, temp);
                temp.TotalActualPayment = actualPaymentRepository.queryTotolMoney(item.ContractGUID);
                conViewModels.Add(temp);

            }
            //返回结果
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
                if (entity.ActualPayments != null) {
                    entity.ActualPayments.ForEach(s => { s.ContractBasicInfo = entity; });
                }
                if (entity.RepaymentPlans != null)
                {
                    entity.RepaymentPlans.ForEach(r => { r.ContractBasicInfo = entity; });
                }
                
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

        /// <summary>
        /// 查询记录项目的一些基本信息添补上已回款总金额
        /// <param name="key">查询关键字</param>
        /// <param name="value">查询需要匹配的值</param>
        /// <returns></returns>
        public List<ContractBasicInfoViewModel> QueryContractBasicInfo(String key, String value)
        {
            //通过关键字和值查询出符合要求的列表
            var contractList = contractBasicInfoRepository.QueryContractBasicInfo(key, value);

            //创建一个合同视图列表对象
            List<ContractBasicInfoViewModel> conViewModels = new List<ContractBasicInfoViewModel>();

            //计算出查出来的合同的实际回款总额
            foreach (var item in contractList)
            {
                ContractBasicInfoViewModel temp = new ContractBasicInfoViewModel();
                temp = Mapper.Map<ContractBasicInfo, ContractBasicInfoViewModel>(item, temp);
                temp.TotalActualPayment = actualPaymentRepository.queryTotolMoney(item.ContractGUID);
                conViewModels.Add(temp);

            }
            
            //返回结果
            return conViewModels;
        }

        /// <summary>
        /// 获取数据库数据总条数
        /// <returns></returns>
        public int getTotalCount() {
            return contractBasicInfoRepository.getTotalCount();
        }
        #endregion
    }
}