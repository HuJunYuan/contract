using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;

using EIP.Model;
using EIP.Entity;
namespace EIP.Service.AutoMapper.Profiles
{
    public class StudentProfile : BaseProfile
    {
        protected override void Configure()
        {
            //数据字典添加映射
            CreateMap<CodeMasterSaveViewModel, CodeMaster>()
                .ForMember(des => des.PrepareField1, map => map.Ignore())
                .ForMember(des => des.PrepareField2, map => map.Ignore())
                .ForMember(des => des.PrepareField3, map => map.Ignore())
                .ForMember(des => des.PrepareField4, map => map.Ignore())
                .ForMember(des => des.ParentId, map => { map.MapFrom(sou => sou.ParentId.HasValue ? sou.ParentId : 0); });






           

           
        }
    }
}