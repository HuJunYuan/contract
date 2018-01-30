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

using CoreLand.Framework.UnitTest;
using CoreLand.Framework;
using CoreLand.Framework.Aop;
using CoreLand.Framework.Authentication;
using EIP.Entity;
using EIP.Service;
using EIP.Model;

namespace EIP.ServiceTest
{
    [TestClass]
    public class ContractBasicInfoServiceTest : ServiceUnitTest
    {
        IContractBasicInfoService service;
        public override void AfterInit()
        {
            // 应用消息配置导入
            CoreLand.Framework.Message.MessageManager.Load("Message.config");

            // AutoMapper映射配置导入
            EIP.Service.AutoMapper.Configuration.Configure();

            // 服务实例获取
            service = this.GetService<IContractBasicInfoService>();
            AppContext.User = AppContext.ServiceFactory.GetMembershipAdapter().FindBy("eip");
            
        }
        [TestMethod]
        public void QueryContractBasicInfoWithTotalActualPayment()
        {
            var list = service.QueryContractBasicInfoWithTotalActualPayment(1, 10);
            Assert.IsTrue(list.Count() >= 0);
        }


        [TestMethod]
        public void testGetTotalCount()
        {
            //查询已有数据条数
            int count1 = service.getTotalCount();
            Assert.IsTrue(count1 >= 0);
        }

        [TestMethod]
        public void QueryContractBasicInfo()
        {

            //查询一共有多少条数据
            int count1 = service.getTotalCount();

            //插入一个数据
            ContractBasicInfo model = new ContractBasicInfo();
            model.LogicDeleteFlag = false;
            model.EntryName = "test1";
            model.CustomerName = "test";
            model.Abbreviation = "test";
            service.SaveContractBasicInfo(model);
            service.ServiceContext.Commit();

            //更新刚才插入的数据
            model.EntryName = "test";
            service.SaveContractBasicInfo(model);
            service.ServiceContext.Commit();

            //为其插入list
            model.ActualPayments = new List<ActualPayment>();
            model.RepaymentPlans = new List<RepaymentPlan>();
            service.SaveContractBasicInfo(model);
            service.ServiceContext.Commit();

            //查询数据量有没有增加一条
            int count2 = service.getTotalCount();
            Assert.AreEqual(count1, count2 - 1);

           
            //测试通过传入的查询字段及值来查询数据库
            var enteryNumList = service.QueryContractBasicInfo("EntryName", "test");
            Assert.IsTrue(enteryNumList.Count() >0);
           var CustomerNameList= service.QueryContractBasicInfo("CustomerName", "test");
            Assert.IsTrue(CustomerNameList.Count() >0);
            var AbbreList = service.QueryContractBasicInfo("Abbreviation","test" );
            Assert.IsTrue(AbbreList.Count() >0);

            //删除刚才插入的数据
            service.Delete<ContractBasicInfo>(model.ContractGUID);
            Assert.AreEqual(count1, service.getTotalCount());


        }

        [TestMethod]
        public void SaveContractBasicInfo()
        {
            //查询一共有多少条数据
            int count1 = service.getTotalCount();

            //插入一个数据
            ContractBasicInfo model = new ContractBasicInfo();
            model.LogicDeleteFlag = false;
            model.EntryName = "test";
            service.SaveContractBasicInfo(model);
			service.ServiceContext.Commit();

            //更新刚才插入的数据
            model.EntryName = "test2";
            service.SaveContractBasicInfo(model);
            service.ServiceContext.Commit();

            //为其插入list
            model.ActualPayments = new List<ActualPayment>();
            model.RepaymentPlans = new List<RepaymentPlan>(); 
            service.SaveContractBasicInfo(model);
            service.ServiceContext.Commit();

            //查询数据量有没有增加一条
            int count2 = service.getTotalCount();
            Assert.AreEqual(count1, count2 - 1);

            //删除刚才插入的数据
            service.Delete<ContractBasicInfo>(model.ContractGUID);
            Assert.AreEqual(count1, service.getTotalCount());
        }
    }
}
