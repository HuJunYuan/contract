﻿using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Impl;

namespace EIP.Service.AutoMapper
{
    public class Configuration
    {
        public static void Configure()
        {
            //Mapper.AddProfile<Profiles.PMPostProfile>();
            //Mapper.AddProfile<Profiles.StudentProfile>();
            Mapper.AddProfile<Profiles.ContractProfile>();
            Mapper.AddProfile<Profiles.CodeMasterProfile>();

            Mapper.AddProfile<Profiles.AppConfigProfile>();

            //Mapper.AddProfile<Profiles.XXXProfile>();
            // 忽视默认字段 CreateUserId、CreateUserName、CreateTime、LastUpdateUserId、LastUpdateUserName、LastUpdateTime
            CoreLand.Framework.Service.AutoMapper.Configuration.IgnorePropertyDtoToEntity();


            //验证配置
            Mapper.AssertConfigurationIsValid();
        }


    }
}
