/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:36   创建人：Hujunyuan
  修改时间：                     修改人：          修改内容：
  描    述：
-----------------------------------------------------------------------------*/
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Newtonsoft.Json;
using CoreLand.Framework;
using CoreLand.Framework.UnitTest;
using CoreLand.Framework.Aop;
using CoreLand.Framework.Authentication;
using EIP.Entity;
using EIP.Service;
using EIP.Model;

namespace EIP.ServiceTest
{
    [TestClass]
    public class ActualPaymentServiceTest : ServiceUnitTest
    {
        IActualPaymentService service;
        public override void AfterInit()
        {
            // 应用消息配置导入
            CoreLand.Framework.Message.MessageManager.Load("Message.config");

            // AutoMapper映射配置导入
            EIP.Service.AutoMapper.Configuration.Configure();

            // 服务实例获取
            service = this.GetService<IActualPaymentService>();
            AppContext.User = AppContext.ServiceFactory.GetMembershipAdapter().FindBy("eip");
        }


        [TestMethod]
        public void QueryActualPayment()
        {


            //插入一条数据
            ActualPayment model = new ActualPayment();
            service.SaveActualPayment(model);
            service.ServiceContext.Commit();
            Assert.IsTrue(model.ActualPaymentGUID != null);

            //更新这条数据
            model.ActualPaymentAmount = 1001;
            service.SaveActualPayment(model);
            service.ServiceContext.Commit();
            Assert.IsTrue(model.ActualPaymentAmount == 1001);

            //设置关键字查询数据
            QueryModel querymodel = new QueryModel();
            int totalCount = 0;
            querymodel.Key = model.ActualPaymentGUID.ToString();
            querymodel.PageIndex = 1;
            querymodel.PageSize = 10;
            var actualPayments = service.QueryActualPayment(querymodel, out totalCount);
            Assert.IsTrue(actualPayments.Count() > 0);

            //不设置关键字查询数据
            QueryModel querymodel1 = new QueryModel();
            int totalCount1 = 0;
            querymodel1.Key = "";
            querymodel1.PageIndex = 1;
            querymodel1.PageSize = 10;
            var actualPayments1 = service.QueryActualPayment(querymodel, out totalCount1);
            Assert.IsTrue(actualPayments1.Count() > 0);

            //删除这条数据
            service.Delete<ActualPayment>(model.ActualPaymentGUID);

        }

        [TestMethod]
        public void SaveActualPayment()
        {
            //插入一条数据
            ActualPayment model = new ActualPayment();
            service.SaveActualPayment(model);
			service.ServiceContext.Commit();
            Assert.IsTrue(model.ActualPaymentGUID != null);

            //更新这条数据
            model.ActualPaymentAmount = 1001;
            service.SaveActualPayment(model);
            service.ServiceContext.Commit();
            Assert.IsTrue(model.ActualPaymentAmount==1001);

            //删除这条数据
            service.Delete<ActualPayment>(model.ActualPaymentGUID);
        }

        [TestMethod]
        public void QueryActualPaymentByContractGuid()
        {
            //创建一个新的GUID
            Guid guid = Guid.NewGuid();

            //通过这个新产生的GUID去查，应返回0个
            var model = service.QueryActualPaymentByContractGuid(guid);
            Assert.IsTrue(model.Count() == 0);
        }
    }
}
