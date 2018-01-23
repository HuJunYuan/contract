/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:38   创建人：Hujunyuan
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
    public class RepaymentPlanController : BaseController
    {
        /// <summary>
        /// 合同回款计划列表
        /// </summary>
        /// <returns></returns>
        [ActionName("list")]
        public ActionResult List()
        {
            return View("~/views/repaymentplan/list.cshtml");
        }

        /// <summary>
        /// 查询合同回款计划列表
        /// </summary>
        /// <returns></returns>
        [ActionName("query_repaymentPlan")]
        public JsonResult QueryRepaymentPlan(QueryModel model)
        {
            var result = new QueryResultModel();
            int totalCount = 0;

            var repaymentPlanService = this.GetService<IRepaymentPlanService>();
            result.Data = repaymentPlanService.QueryRepaymentPlan(model, out totalCount);
            result.Total = totalCount;

            return Json(result);
        }

        /// <summary>
        /// 合同回款计划新增视图
        /// </summary>
        /// <returns></returns>
        [ActionName("add")]
        public ActionResult Add()
        {
            var entity = new RepaymentPlan();
            return View("~/views/repaymentplan/form.cshtml", entity);
        }

        /// <summary>
        /// 合同回款计划编辑视图
        /// </summary>
        /// <param name="repaymentPlantGUID">合同基本信息标识</param>
        /// <returns></returns>
        [ActionName("edit")]
        public ActionResult Edit(Guid repaymentPlantGUID)
        {
            var entity = new RepaymentPlan();

            try
            {
                var repaymentPlanService = this.GetService<IRepaymentPlanService>();
                entity = repaymentPlanService.Find<RepaymentPlan>(repaymentPlantGUID);

            }
            catch (CLApplicationException ex)
            {
                //修改时若发生异常则提示异常信息，并关闭修改界面
                this.ShowAppErrorMessage(ex.Message, MessageFuncOption.CloseBrowserWindow);
            }

            return View("~/views/repaymentplan/form.cshtml", entity);
        }

        /// <summary>
        /// 合同回款计划编辑视图
        /// </summary>
        /// <param name="repaymentPlantGUID">合同基本信息标识</param>
        /// <returns></returns>
        [ActionName("detail")]
        public ActionResult Detail(Guid repaymentPlantGUID)
        {
            var entity = new RepaymentPlan();

            try
            {
                var repaymentPlanService = this.GetService<IRepaymentPlanService>();
                entity = repaymentPlanService.Find<RepaymentPlan>(repaymentPlantGUID);

            }
            catch (CLApplicationException ex)
            {
                //修改时若发生异常则提示异常信息，并关闭修改界面
                this.ShowAppErrorMessage(ex.Message, MessageFuncOption.CloseBrowserWindow);
            }

            return View("~/views/repaymentplan/detail.cshtml", entity);
        }

        /// <summary>
        /// 合同回款计划保存数据操作
        /// </summary>
        /// <param name="model">合同回款计划视图模型</param>
        /// <returns></returns>
        [ActionName("save")]
        public JsonResult Save(RepaymentPlan model)
        {
            var repaymentPlanService = this.GetService<IRepaymentPlanService>();

            if (repaymentPlanService.SaveRepaymentPlan(model)!=null)
            {
                ShowMessage("I10010", MessageFuncOption.CloseBrowserWindow);
            }
            return Json(null);
        }


        /// <summary>
        /// 删除合同回款计划
        /// </summary>
        /// <param name="repaymentPlantGUID">合同基本信息标识</param>
        /// <returns>返回操作结果</returns>
        [ActionName("remove")]
        public JsonResult Remove(Guid repaymentPlantGUID)
        {
            var repaymentPlanService = this.GetService<IRepaymentPlanService>();

            repaymentPlanService.LogicDelete<RepaymentPlan>(repaymentPlantGUID);
            ShowMessage("I10030");

            return Json(null);
        }
    }
}
