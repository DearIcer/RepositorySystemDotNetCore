﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class R_UserInfo_RoleInfo : BaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [MaxLength(36)]
        public string UserId { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        [MaxLength(36)]
        public string RoleId { get; set; }
    }
}
