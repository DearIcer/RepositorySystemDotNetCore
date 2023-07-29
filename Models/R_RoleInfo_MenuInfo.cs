using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class R_RoleInfo_MenuInfo : BaseEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [MaxLength(36)]
        public string RoleId { get; set; }
        /// <summary>
        /// 菜单id
        /// </summary>
        [MaxLength(36)]
        public string MenuId { get; set; }
    }
}
