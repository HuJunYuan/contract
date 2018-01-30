/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:37   创建人：Hujunyuan
  修改时间：                     修改人：          修改内容：
  描    述：
-----------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using CoreLand.Framework;
using CoreLand.Framework.Service;
using CoreLand.Framework.Web;
using EIP.Entity;
using EIP.Model;
using EIP.Service;

namespace EIP.Web.Controllers
{
    public class ContractBasicInfoController : BaseController
    {
        /// <summary>
        /// 记录项目的一些基本信息列表
        /// </summary>
        /// <returns></returns>
        [ActionName("list")]
        public ActionResult List()
        {
            return View("~/views/contractbasicinfo/list.cshtml");
        }

        /// <summary>
        /// 查询记录项目的一些基本信息列表
        /// </summary>
        /// <returns></returns>
        [ActionName("query_contractBasicInfo")]
        public JsonResult QueryContractBasicInfo(String key, String value)
        {
            var result = new QueryResultModel();
            var contractBasicInfoService = this.GetService<IContractBasicInfoService>();
            result.Data = contractBasicInfoService.QueryContractBasicInfo(key,value);
            return Json(result);
        }


        /// <summary>
        /// 查询记录项目的一些基本信息列表，附上回款总金额
        /// </summary>
        /// <returns></returns>
        [ActionName("query_contractBasicInfoWithTotalActualPayment")]
        public JsonResult QueryContractBasicInfoWithTotalActualPayment(int PageIndex, int PageSize)
        {
            var result = new QueryResultModel();
            //int pageNumber = PageIndex ==null? 1:int.Parse(PageIndex);     //第几页的数据  
            //int pageSize = PageSize == null ? 10: int.Parse(PageSize);  //每页多少条数据  
            
            var contractBasicInfoService = this.GetService<IContractBasicInfoService>();
            result.Data = contractBasicInfoService.QueryContractBasicInfoWithTotalActualPayment(PageIndex,PageSize);
            result.Total = contractBasicInfoService.getTotalCount();
            return Json(result);
        }

        /// <summary>
        /// 记录项目的一些基本信息新增视图
        /// </summary>
        /// <returns></returns>
        [ActionName("add")]
        public ActionResult Add()
        {
            var entity = new ContractBasicInfo();
            return View("~/views/contractbasicinfo/form.cshtml", entity);
        }

        /// <summary>
        /// 记录项目的一些基本信息编辑视图
        /// </summary>
        /// <param name="contractGUID">合同基本信息标识</param>
        /// <returns></returns>
        [ActionName("edit")]
        public ActionResult Edit(Guid ContractGUID)
        {
            var entity = new ContractBasicInfo();

            try
            {
                var contractBasicInfoService = this.GetService<IContractBasicInfoService>();
                entity = contractBasicInfoService.Find<ContractBasicInfo>(ContractGUID);

            }
            catch (CLApplicationException ex)
            {
                //修改时若发生异常则提示异常信息，并关闭修改界面
                this.ShowAppErrorMessage(ex.Message);
            }

            return View("~/views/contractbasicinfo/form.cshtml", entity);
        }

        /// <summary>
        /// 记录项目的一些基本信息编辑视图
        /// </summary>
        /// <param name="contractGUID">合同基本信息标识</param>
        /// <returns></returns>
        [ActionName("detail")]
        public ActionResult Detail(Guid contractGUID)
        {
            var entity = new ContractBasicInfo();

            try
            {
                var contractBasicInfoService = this.GetService<IContractBasicInfoService>();
                entity = contractBasicInfoService.Find<ContractBasicInfo>(contractGUID);

            }
            catch (CLApplicationException ex)
            {
                //修改时若发生异常则提示异常信息，并关闭修改界面
                this.ShowAppErrorMessage(ex.Message);
            }

            return View("~/views/contractbasicinfo/detail.cshtml", entity);
        }

        /// <summary>
        /// 记录项目的一些基本信息保存数据操作
        /// </summary>
        /// <param name="model">记录项目的一些基本信息视图模型</param>
        /// <returns></returns>
        [ActionName("save")]
        public JsonResult Save(ContractBasicInfo model)
        {
            var contractBasicInfoService = this.GetService<IContractBasicInfoService>();

            if (contractBasicInfoService.SaveContractBasicInfo(model)!=null)
            {
                ShowMessage("I10010");
            }
            return Json(null);
        }


        /// <summary>
        /// 删除记录项目的一些基本信息
        /// </summary>
        /// <param name="contractGUID">合同基本信息标识</param>
        /// <returns>返回操作结果</returns>
        [ActionName("remove")]
        public JsonResult Remove(Guid contractGUID)
        {
            var contractBasicInfoService = this.GetService<IContractBasicInfoService>();

            contractBasicInfoService.LogicDelete<ContractBasicInfo>(contractGUID);
            ShowMessage("I10030");

            return Json(null);
        }
    }
}
