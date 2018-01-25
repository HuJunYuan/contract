using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;

using EIP.Model;
using EIP.Entity;
namespace EIP.Service.AutoMapper.Profiles
{
    public class ContractProfile : BaseProfile
    {
        protected override void Configure()
        {
            //数据字典添加映射
            CreateMap<ContractBasicInfo, ContractBasicInfo>();
            //.ForMember(des => des.ContractGUID, map => map.Ignore());

            CreateMap<ActualPayment, ActualPayment>();
            //.ForMember(des => des.ContractGUID, map => map.Ignore());
            CreateMap<RepaymentPlan, RepaymentPlan>();
                //.ForMember(des => des.ContractGUID, map => map.Ignore());









        }
    }
}