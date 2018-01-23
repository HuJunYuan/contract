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
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;

using CoreLand.Framework;
using CoreLand.Framework.Data;
using CoreLand.Framework.Code;
using EIP.Model;
using EIP.Entity;

namespace EIP.Repository
{
    /// <summary>
    /// 合同回款计划仓储
    /// </summary>
    public class RepaymentPlanRepository : DefaultRepository<RepaymentPlan>
    {

        public RepaymentPlanRepository(IUnitOfWork unitOfWork, IRepositoryFactory factory)
            : base(unitOfWork, factory)
        {

        }

        /// <summary>
        /// 查询合同回款计划
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        public List<RepaymentPlan> QueryRepaymentPlan(QueryModel model, out int totalCount)
        {
            //查询数据
            var searchKey = (string.IsNullOrEmpty(model.Key) ? "%" : "%" + model.Key.Trim() + "%");
            string sql = "select * from dbo.RepaymentPlan where LogicDeleteFlag=0 and TODO like @p0 ";

            //分页查询必须要有排序字段
            model.SortField = string.IsNullOrEmpty(model.SortField) ? "TODO" : model.SortField;

            var repaymentPlans = this.LoadPageEntitiesBySql<RepaymentPlan>(
                       model.PageIndex,
                       model.PageSize,
                       out totalCount,
                       sql,
                       model.SortField + " " + model.SortOrder,
                       searchKey
                       ).ToList();

            return repaymentPlans;
        }

    }
}
