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
            CreateMap<ContractBasicInfo, ContractBasicInfo>()
            .ForMember(des => des.CreateUserId, map => map.Ignore())
            .ForMember(des => des.LastUpdateUserId, map => map.Ignore())
            .ForMember(des => des.ActualPayments, map => map.Ignore())
            .ForMember(des => des.RepaymentPlans, map => map.Ignore());

            CreateMap<ActualPayment, ActualPayment>()
            .ForMember(des => des.ContractBasicInfo, map => map.Ignore());


            CreateMap<RepaymentPlan, RepaymentPlan>()
                .ForMember(des => des.ContractBasicInfo, map => map.Ignore());


            CreateMap<ContractBasicInfo, ContractBasicInfoViewModel>()
                .ForMember(des=>des.TotalActualPayment,map=>map.Ignore());






        }
    }
}