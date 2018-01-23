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
        }


        [TestMethod]
        public void QueryActualPayment()
        {
            //查询数据
            QueryModel model = new QueryModel();
            int totalCount = 0;
            model.Key = "test";
            model.PageIndex = 1;
            model.PageSize = 10;

            var actualPayments = service.QueryActualPayment(model, out totalCount);

        }

        [TestMethod]
        public void SaveActualPayment()
        {
            ActualPayment model = new ActualPayment{
                
            };
            service.SaveActualPayment(model);
			service.ServiceContext.Commit();
        }
    }
}
