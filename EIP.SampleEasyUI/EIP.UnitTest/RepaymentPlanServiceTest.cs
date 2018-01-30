/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2018-01-23 12:46:37   创建人：Hujunyuan
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
    public class RepaymentPlanServiceTest : ServiceUnitTest
    {
        IRepaymentPlanService service;
        public override void AfterInit()
        {
            // 应用消息配置导入
            CoreLand.Framework.Message.MessageManager.Load("Message.config");

            // AutoMapper映射配置导入
            EIP.Service.AutoMapper.Configuration.Configure();

            // 服务实例获取
            service = this.GetService<IRepaymentPlanService>();
            AppContext.User = AppContext.ServiceFactory.GetMembershipAdapter().FindBy("eip"); 
        }


        [TestMethod]
        public void QueryRepaymentPlan()
        {
            //插入一条数据
            RepaymentPlan model = new RepaymentPlan();
            service.SaveRepaymentPlan(model);
            service.ServiceContext.Commit();
            Assert.IsTrue(model.RepaymentPlantGUID != null);

            //更新这条数据
            model.RepaymentPlanAmount = 1001;
            service.SaveRepaymentPlan(model);
            service.ServiceContext.Commit();
            Assert.IsTrue(model.RepaymentPlanAmount == 1001);

            //设置关键字查询数据
            QueryModel querymodel = new QueryModel();
            int totalCount = 0;
            querymodel.Key = model.RepaymentPlantGUID.ToString();
            querymodel.PageIndex = 1;
            querymodel.PageSize = 10;
            var list = service.QueryRepaymentPlan(querymodel, out totalCount);
            Assert.IsTrue(list.Count() > 0);

            //不设置关键字查询数据
            QueryModel querymodel1 = new QueryModel();
            int totalCount1 = 0;
            querymodel1.Key = "";
            querymodel1.PageIndex = 1;
            querymodel1.PageSize = 10;
            var list1 = service.QueryRepaymentPlan(querymodel, out totalCount1);
            Assert.IsTrue(list1.Count() > 0);

            //删除这条数据
            service.Delete<ActualPayment>(model.RepaymentPlantGUID);

        }

        [TestMethod]
        public void SaveRepaymentPlan()
        {

            //插入一条数据
            RepaymentPlan model = new RepaymentPlan();
            service.SaveRepaymentPlan(model);
            service.ServiceContext.Commit();
            Assert.IsTrue(model.RepaymentPlantGUID != null);

            //更新这条数据
            model.RepaymentPlanAmount = 1001;
            service.SaveRepaymentPlan(model);
            service.ServiceContext.Commit();
            Assert.IsTrue(model.RepaymentPlanAmount == 1001);

            //删除这条数据
            service.Delete<ActualPayment>(model.RepaymentPlantGUID);
        }

        [TestMethod]
        public void QueryRepaymentPlanByContractGuid()
        {
            //创建一个新的GUID
            Guid guid = Guid.NewGuid();

            //通过这个新产生的GUID去查，应返回0个
            var model = service.QueryRepaymentPlanByContractGuid(guid);
            Assert.IsTrue(model.Count() == 0);
        }
    }
}
