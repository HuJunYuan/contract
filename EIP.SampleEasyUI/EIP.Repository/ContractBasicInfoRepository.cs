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
    /// 记录项目的一些基本信息仓储
    /// </summary>
    public class ContractBasicInfoRepository : DefaultRepository<ContractBasicInfo>
    {

        public ContractBasicInfoRepository(IUnitOfWork unitOfWork, IRepositoryFactory factory)
            : base(unitOfWork, factory)
        {

        }

        /// <summary>
        ///// 查询记录项目的一些基本信息
        ///// </summary>
        ///// <param name="model">翻页查询基本条件</param>
        ///// <param name="totalCount">整体查询结果件数</param>
        ///// <returns></returns>
        //public List<ContractBasicInfo> QueryContractBasicInfo(QueryModel model, out int totalCount)
        //{
        //    //查询数据
        //    var searchKey = (string.IsNullOrEmpty(model.Key) ? "%" : "%" + model.Key.Trim() + "%");
        //    string sql = "select * from dbo.ContractBasicInfo where LogicDeleteFlag=0 and EntryName like @p0 ";
        //
        //    //分页查询必须要有排序字段
        //    model.SortField = string.IsNullOrEmpty(model.SortField) ? "ContractGUID" : model.SortField;
        //
        //    var contractBasicInfos = this.LoadPageEntitiesBySql<ContractBasicInfo>(
        //               model.PageIndex,
        //               model.PageSize,
        //               out totalCount,
        //               sql,
        //               model.SortField + " " + model.SortOrder,
        //               searchKey
        //               ).ToList();
        //
        //    return contractBasicInfos;
        //}


        /// <summary>
        /// 查询记录项目的一些基本信息
        /// </summary>
        /// <returns></returns>
        public List<ContractBasicInfo> QueryContractBasicInfo()
        {
            var results = this.GetEntity().Where(s => s.LogicDeleteFlag == false).ToList();
            return results;
          
        }

        /// <summary>
        /// 查询记录项目的一些基本信息
        /// </summary>
        /// <param name="pageNumber">查询页数</param>
        /// <param name="pageSize">查询页面大小</param>
        /// <returns></returns>
        public List<ContractBasicInfo> QueryContractBasicInfo(int pageNumber, int pageSize) {
            int totalcount = this.getTotalCount();
            List<ContractBasicInfo> results = new List<ContractBasicInfo>();
            if (pageNumber * pageSize > totalcount) {
                results = this.GetEntity().Where(s => s.LogicDeleteFlag == false).OrderBy(s => s.CreateTime).Skip((pageNumber - 1) * pageSize).Take(totalcount - pageSize*(pageNumber-1)).ToList();
            }
            else
            {
                results = this.GetEntity().Where(s => s.LogicDeleteFlag == false).OrderBy(s => s.CreateTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }
            
            return results;
        }

        /// <summary>
        /// 查询记录项目的一些基本信息
        /// </summary>
        /// <param name="key">查询关键字</param>
        /// <param name="value">查询需要匹配的值</param>
        /// <returns></returns>
        public List<ContractBasicInfo> QueryContractBasicInfo(String key, String value)
        {


            List<ContractBasicInfo> conList = new List<ContractBasicInfo>();



         switch (key)
          {
                case "EntryName":
                  conList = this.GetEntity().Where(s => s.EntryName.Contains(value)).ToList();
                    break;
                case "CustomerName":
                  conList = this.GetEntity().Where(s => s.CustomerName.Contains(value)).ToList();
                    break;
                case "Abbreviation":
                  conList = this.GetEntity().Where(s => s.Abbreviation.Contains(value)).ToList();
                    break;
            }
            return conList;
        }


        /// <summary>
        /// 获取数据库已有数据条数
        /// </summary>
        /// <returns></returns>
        public int getTotalCount() {
            return this.GetEntity().Where(s => s.LogicDeleteFlag == false).ToList().Count();
        }
    }
}
