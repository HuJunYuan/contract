﻿/*-----------------------------------------------------------------------------
  版 本 号：V1.0 Copyright (c) Coreland.com.  All Rights Reserved.
  创建时间：2017-12-20 17:22:14   创建人：Hujunyuan
  修改时间：                     修改人：          修改内容：
  描    述：
-----------------------------------------------------------------------------*/
using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using Newtonsoft.Json;
using AutoMapper;

using CoreLand.Framework;
using CoreLand.Framework.Data;
using CoreLand.Framework.Service;
using CoreLand.Framework.Code;
using CoreLand.Framework.Authentication;
using CoreLand.Framework.Helpers;
using EIP.Model;
using EIP.Repository;
using EIP.Entity;

namespace EIP.Service
{
    /// <summary>
    /// 教室信息
    ///    服务
    /// </summary>
    public class ClassroomService : EntityBaseService, IClassroomService
    {
        #region 初始化

        /// <summary>
        /// 教室信息
        ///    仓储
        /// </summary>
        private ClassroomRepository classroomRepository = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uow">工作单元</param>
        /// <param name="factory">仓储创建工厂</param>
        public ClassroomService(IUnitOfWork uow, IRepositoryFactory factory)
            : base(uow, factory)
        {
            classroomRepository = this.CreateRepository<ClassroomRepository>();
        }

        #endregion

        #region IClassroomService method

        /// <summary>
        /// 查询教室信息
        ///    
        /// </summary>
        /// <param name="model">翻页查询基本条件</param>
        /// <param name="totalCount">整体查询结果件数</param>
        /// <returns></returns>
        public List<Classroom> QueryClassroom(QueryModel model, out int totalCount)
        {
            return classroomRepository.QueryClassroom(model, out totalCount);
        }

        /// <summary>
        /// 处理教 室信息
        ///    
        /// 根据 id 编号判断是否是添加还是更新，然后调用相应的方法进行处理
        /// </summary>
        /// <param name="model">教室信息    信息</param>
        /// <returns>处理是否成功</returns>
        public int SaveClassroom(Classroom model)
        {
            //检查是否存在重复数据
            var entity = this.Find<Classroom>(model.ClassroomId);

            //更新数据 ， 否则新增数据
            if (entity != null)
            {
                //更新数据
                entity = Mapper.Map<Classroom, Classroom>(model, entity);
                this.classroomRepository.Update(entity);
            }
            else
            {
                //录入数据
                this.classroomRepository.Insert(model);
            }

            return model.ClassroomId;
        }

        /// <summary>
        /// 删除教室信息
        ///    
        /// 根据 id 编号判断是否存在这条数据，根据相应的结果进行处理
        /// </summary>
        /// <param name="model">教室信息    信息</param>
        /// <returns>处理是否成功</returns>
        /// 
        public bool DeleteClassroom(Classroom model)
        {
            // 检查是否存在这条数据
            var entity = this.Find<Classroom>(model.ClassroomId);
            bool flag = false;
            //如果存在执行删除操作，否则不执行
            if (entity != null)
            {
                //执行删除操作
                this.Delete<Classroom>(model.ClassroomId);
                ServiceContext.Commit();
                //检查是否删除成功
                var isComplete = this.Find<Classroom>(model.ClassroomId);
                if (isComplete == null) flag = true;
            }
            else flag = false;
            return flag;
        }
        #endregion

        #region private method

        #endregion
    }
}