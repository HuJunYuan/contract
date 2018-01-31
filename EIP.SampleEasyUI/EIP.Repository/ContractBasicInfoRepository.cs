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
        /// 查询合同基本信息表中所有未逻辑删除的数据
        /// </summary>
        /// <returns></returns>
        public List<ContractBasicInfo> QueryContractBasicInfo()
        {
            var results = this.GetEntity().Where(s => s.LogicDeleteFlag == false).ToList();
            return results;
          
        }

        /// <summary>
        /// 使用分页查询指定页码的数据
        /// </summary>
        /// <param name="pageNumber">查询页数</param>
        /// <param name="pageSize">查询页面大小</param>
        /// <returns></returns>
        public List<ContractBasicInfo> QueryContractBasicInfo(int pageNumber, int pageSize) {
            //获取合同信息表中的总条数
            int totalcount = this.getTotalCount();

            List<ContractBasicInfo> results = new List<ContractBasicInfo>();
            if (pageNumber * pageSize > totalcount) {
                //页码*页面大小大于数据库中求删除数据总条数
                results = this.GetEntity().Where(s => s.LogicDeleteFlag == false).OrderBy(s => s.CreateTime).Skip((pageNumber - 1) * pageSize).Take(totalcount - pageSize*(pageNumber-1)).ToList();
            }
            else
            {
                //页码*页面大小小于于数据库中求删除数据总条数
                results = this.GetEntity().Where(s => s.LogicDeleteFlag == false).OrderBy(s => s.CreateTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }
            
            return results;
        }

        /// <summary>
        /// 通过关键字和值查询指定的数据
        /// </summary>
        /// <param name="key">查询关键字</param>
        /// <param name="value">查询需要匹配的值</param>
        /// <returns></returns>
        public List<ContractBasicInfo> QueryContractBasicInfo(String key, String value)
        {
            List<ContractBasicInfo> conList = new List<ContractBasicInfo>();

         switch (key)
          {
                //使用合同名进行模糊查询
                case "EntryName":
                  conList = this.GetEntity().Where(s => s.EntryName.Contains(value)).ToList();
                    break;

                //使用客户名进行模糊查询
                case "CustomerName":
                  conList = this.GetEntity().Where(s => s.CustomerName.Contains(value)).ToList();
                    break;

                //使用合同简称进行模糊查询
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
