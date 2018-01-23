//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2016-05-03 15:23:22 by ding
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CoreLand.Framework.Data;

namespace EIP.Entity
{
    [Table("CodeMaster", Schema = "pub")]
    public class CodeMaster : BusinessEntity
    {
        /// <summary>
        /// 主键
        /// 不能为空
        /// </summary>	
        [Key, Required]
        public int Id { get; set; }

        /// <summary>
        /// 父节点ID
        /// 可为空
        /// 最大长度为100     
        /// </summary>	
        public int? ParentId { get; set; }

        /// <summary>
        /// 编码
        /// 可为空
        /// 最大长度为100     
        /// </summary>	
        [MaxLength(100)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// 可为空
        /// 最大长度为200     
        /// </summary>	
        [MaxLength(200)]
        public string Text { get; set; }

        /// <summary>
        /// 略称
        /// 可为空
        /// 最大长度为200     
        /// </summary>	
        [MaxLength(200)]
        public string ShortText { get; set; }
        /// <summary>
        /// 汉字拼音
        /// 可为空
        /// 最大长度为200     
        /// </summary>	
        [MaxLength(200)]
        public string Pinyin { get; set; }


        /// <summary>
        /// 显示顺序
        /// 可为空
        /// </summary>
        public int ShowIndex { get; set; }

        /// <summary>
        /// 预备字段1
        /// 可为空
        /// 最大长度为200     
        /// </summary>	
        [MaxLength(200)]
        public string PrepareField1 { get; set; }

        /// <summary>
        /// 预备字段2
        /// 可为空
        /// 最大长度为200     
        /// </summary>	
        [MaxLength(200)]
        public string PrepareField2 { get; set; }

        /// <summary>
        /// 预备字段3
        /// 可为空
        /// 最大长度为200     
        /// </summary>	
        [MaxLength(200)]
        public string PrepareField3 { get; set; }

        /// <summary>
        /// 预备字段4
        /// 可为空
        /// 最大长度为200     
        /// </summary>	
        [MaxLength(200)]
        public string PrepareField4 { get; set; }
    }
}