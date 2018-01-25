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
    public class ActualPaymentController : BaseController
    {
        /// <summary>
        /// 实际回款列表
        /// </summary>
        /// <returns></returns>
        [ActionName("list")]
        public ActionResult List(Guid ContractGUID)
        {
            ViewBag.contractGuid = ContractGUID;
            return View("~/views/actualpayment/list.cshtml");
        }

        /// <summary>
        /// 查询实际回款列表
        /// </summary>
        /// <returns></returns>
        [ActionName("query_actualPayment")]
        public JsonResult QueryActualPayment(QueryModel model)
        {
            var result = new QueryResultModel();
            int totalCount = 0;

            var actualPaymentService = this.GetService<IActualPaymentService>();
            result.Data = actualPaymentService.QueryActualPayment(model, out totalCount);
            result.Total = totalCount;

            return Json(result);
        }

        /// <summary>
        /// 实际回款新增视图
        /// </summary>
        /// <returns></returns>
        [ActionName("add")]
        public ActionResult Add()
        {
            var entity = new ActualPayment();
            return View("~/views/actualpayment/form.cshtml", entity);
        }
        

        /// <summary>
        /// 获取指定合同的实际回款信息
        /// </summary>
        /// <returns></returns>
        [ActionName("loadPanel")]
        public JsonResult loadPanel(Guid ContractGUID)
        {
            var result = new QueryResultModel();
            int totalcount = 0;
            var actualPaymentService = this.GetService<IActualPaymentService>();
            result.Data = actualPaymentService.QueryActualPaymentByContractGuid(ContractGUID);
            result.Total = totalcount;
            return Json(result);
        }

        /// <summary>
        /// 实际回款编辑视图
        /// </summary>
        /// <param name="actualPaymentGUID">实际回款标识串</param>
        /// <returns></returns>
        [ActionName("edit")]
        public ActionResult Edit(Guid ActualPaymentGUID)
        {
            var entity = new ActualPayment();

            try
            {
                var actualPaymentService = this.GetService<IActualPaymentService>();
                entity = actualPaymentService.Find<ActualPayment>(ActualPaymentGUID);

            }
            catch (CLApplicationException ex)
            {
                //修改时若发生异常则提示异常信息，并关闭修改界面
                this.ShowAppErrorMessage(ex.Message, MessageFuncOption.CloseBrowserWindow);
            }

            return View("~/views/actualpayment/form.cshtml", entity);
        }

        /// <summary>
        /// 实际回款编辑视图
        /// </summary>
        /// <param name="actualPaymentGUID">实际回款标识串</param>
        /// <returns></returns>
        [ActionName("detail")]
        public ActionResult Detail(Guid ActualPaymentGUID)
        {
            var entity = new ActualPayment();

            try
            {
                var actualPaymentService = this.GetService<IActualPaymentService>();
                entity = actualPaymentService.Find<ActualPayment>(ActualPaymentGUID);

            }
            catch (CLApplicationException ex)
            {
                //修改时若发生异常则提示异常信息，并关闭修改界面
                this.ShowAppErrorMessage(ex.Message, MessageFuncOption.CloseBrowserWindow);
            }

            return View("~/views/actualpayment/detail.cshtml", entity);
        }

        /// <summary>
        /// 实际回款保存数据操作
        /// </summary>
        /// <param name="model">实际回款视图模型</param>
        /// <returns></returns>
        [ActionName("save")]
        public JsonResult Save(ActualPayment model)
        {
            var actualPaymentService = this.GetService<IActualPaymentService>();

            if (actualPaymentService.SaveActualPayment(model)!=null)
            {
                ShowMessage("I10010");
            }
            return Json(null);
        }


        /// <summary>
        /// 删除实际回款
        /// </summary>
        /// <param name="actualPaymentGUID">实际回款标识串</param>
        /// <returns>返回操作结果</returns>
        [ActionName("remove")]
        public JsonResult Remove(Guid ActualPaymentGUID)
        {
            var actualPaymentService = this.GetService<IActualPaymentService>();

            actualPaymentService.LogicDelete<ActualPayment>(ActualPaymentGUID);
            ShowMessage("I10030");

            return Json(null);
        }
    }
}
