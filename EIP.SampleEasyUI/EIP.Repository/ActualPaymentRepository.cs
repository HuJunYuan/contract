/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:33   创建人：Hujunyuan
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
    /// 实际回款仓储
    /// </summary>
    public class ActualPaymentRepository : DefaultRepository<ActualPayment>
    {

        public ActualPaymentRepository(IUnitOfWork unitOfWork, IRepositoryFactory factory)
            : base(unitOfWork, factory)
        {

        }

        /// <summary>
        /// 查询实际回款
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        public List<ActualPayment> QueryActualPayment(QueryModel model, out int totalCount)
        {
            //查询数据
            var searchKey = (string.IsNullOrEmpty(model.Key) ? "%" : "%" + model.Key.Trim() + "%");
            string sql = "select * from dbo.ActualPayment where LogicDeleteFlag=0 and ActualPaymentGUID like @p0 ";

            //分页查询必须要有排序字段
            model.SortField = string.IsNullOrEmpty(model.SortField) ? "ActualPaymentGUID" : model.SortField;

            var actualPayments = this.LoadPageEntitiesBySql<ActualPayment>(
                       model.PageIndex,
                       model.PageSize,
                       out totalCount,
                       sql,
                       model.SortField + " " + model.SortOrder,
                       searchKey
                       ).ToList();

            return actualPayments;
        }

    }
}
